﻿using System;
using ColossalGame.Controllers;
using ColossalGame.Services;
using NUnit.Framework;

namespace ColossalServiceTests
{
    [TestFixture]
    public class LoginTests
    {
        private LoginService _loginService;
        [SetUp]
        public void Setup()
        {
            _loginService = new LoginService(new UserService());
        }

        [Test]
        public void TestSignUp()
        {
            Console.WriteLine(_loginService.DeleteUser("coolAccount"));
            bool createdSuccessfully = _loginService.SignUp("coolAccount", "coolpassword");
            Assert.True(createdSuccessfully);
            Assert.Throws<UserAlreadyExistsException>((() => _loginService.SignUp("coolAccount","coolpassword")));
        }

        [Test]
        public void TestSignIn()
        {
            Console.WriteLine(_loginService.DeleteUser("coolAccount"));
            Assert.True( _loginService.SignUp("coolAccount", "coolpassword"));
            Assert.NotNull( _loginService.SignIn("coolAccount", "coolpassword"));
        }

        
    }
}