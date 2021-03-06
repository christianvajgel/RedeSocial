﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Services.Account;
using RedeSocial.Web.ViewModel.Account;

namespace RedeSocial.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService AccountService { get; set; }
        private IAccountIdentityManager AccountIdentityManager { get; set; }

        public AccountController(IAccountService accountService, IAccountIdentityManager accountIdentityManager)
        {
            this.AccountService = accountService;
            this.AccountIdentityManager = accountIdentityManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(String returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                //var result = await this.AccountIdentityManager.Login(model.Email, model.Password);
                var result = await this.AccountIdentityManager.Login(model.UserName, model.Password);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Login ou senha inválidos");
                    return View(model);
                }
                if (!String.IsNullOrWhiteSpace(returnUrl)) 
                {
                    return Redirect(returnUrl);
                }
                return Redirect("/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return View(model);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        //{
        //    try
        //    {
        //        var result = await this.AccountIdentityManager.Login(model.Email, model.Password);

        //        if (!result.Succeeded)
        //        {
        //            ModelState.AddModelError(string.Empty, "Login ou senha inválidos");
        //            return View(model);
        //        }
        //        if (!String.IsNullOrWhiteSpace(returnUrl)) 
        //        {
        //            return Redirect(returnUrl);
        //        }
        //        return Redirect("/");
        //    }
        //    catch
        //    {
        //        ModelState.AddModelError(string.Empty, "Erro.");
        //        return View(model);
        //    }
        //}

    }
}
