﻿using System.Collections.Generic;
using MyHome.DataRepository;
using MyHome.Persistence;

namespace MyHome.Services
{
    public enum CategoryType
    {
        Expense = 1,
        Income,
        PaymentMethod
    }

    public class CategoryService
    {
        public Dictionary<CategoryType, ICategoryService> CategoryHandlers { get; } = new Dictionary<CategoryType, ICategoryService>();

        public Dictionary<CategoryType, string> CategoryTypeNames => new Dictionary<CategoryType, string>
           {
                {CategoryType.Expense, "Expense Categories"},
                {CategoryType.Income, "Income Categories"},
                {CategoryType.PaymentMethod, "Payment Methods"}
           };

        public CategoryService(AccountingDataContext context)
        {
            var expenseCategoryService = new ExpenseCategoryService(new ExpenseCategoryRepository(context));
            var incomeCategoryService = new IncomeCategoryService(new IncomeCategoryRepository(context));
            var paymentMethodService = new PaymentMethodService(new PaymentMethodRepository(context));

            CategoryHandlers = new Dictionary<CategoryType, ICategoryService>
            {
                {CategoryType.Expense, expenseCategoryService},
                {CategoryType.Income, incomeCategoryService},
                {CategoryType.PaymentMethod, paymentMethodService}
            };
        }
    }
}
