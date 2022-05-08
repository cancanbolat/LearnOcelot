using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public static class TokenHandler
{
    public static IConfiguration configuration;
    public static dynamic CreateAccessToken()
    {
        SymmetricSecurityKey symetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Security"]));
        TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = symetricSecurityKey,
            ValidateIssuer = true,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = configuration["JWT:Audience"],
            ValidateLifetime = true,
            ClockSkew = System.TimeSpan.Zero,
            RequireExpirationTime = true
        };
        DateTime now = DateTime.UtcNow;
        JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: configuration["JWT:Issuer"],
            audience: configuration["JWT:Audience"],
            claims: new List<Claim>{
                new Claim(ClaimTypes.Name, "can")
            },
            notBefore: now,
            expires: now.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );
        return new
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
            Expires = TimeSpan.FromMinutes(2).TotalSeconds
        };
    }
}