using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name Cannot be Empty ");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Category Description Cannot be Empty");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Category name must be more than 3 charecters");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Category name must be lower than 20 charecters");
        }
    }
}
