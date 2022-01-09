using AutoMapper;
using ElSaiys.DTOs;
using ElSaiys.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElSaiys.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _map;

        public UserRepository(ApplicationDbContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task<UserResult> CarOwner(string slug)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Slug == slug && e.IsDelete == false);

            if (user == null)
                return new UserResult { Success = false, ErrorCode = "Usr005" };

            return new UserResult
            {
                Success = true,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsPrivate = user.IsPrivate,
                Slug = user.Slug
            };
        }
    }
}
