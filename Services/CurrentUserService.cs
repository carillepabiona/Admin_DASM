using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Text;


namespace Admin_DASM.Services
{
    public class CurrentUserService
    {
        private readonly ILocalStorageService _localStorage;

        public CurrentUserService(
            ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        private const string KEY = "currentUser";

        // =========================================
        // SAVE USER
        // =========================================

        public async Task SaveUser(UserSession user)
        {
            await _localStorage.SetItemAsync(KEY, user);
        }

        // =========================================
        // GET USER
        // =========================================

        public async Task<UserSession?> GetUser()
        {
            return await _localStorage
                .GetItemAsync<UserSession>(KEY);
        }

        // =========================================
        // LOGOUT
        // =========================================

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(KEY);
        }
    }

    // =========================================
    // USER SESSION MODEL
    // =========================================

    public class UserSession
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = "";

        public string Username { get; set; } = "";

        public string Email { get; set; } = "";

        public string ContactNumber { get; set; } = "";

        public string Address { get; set; } = "";

        public int RoleId { get; set; }

        public int AccessLevelId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
