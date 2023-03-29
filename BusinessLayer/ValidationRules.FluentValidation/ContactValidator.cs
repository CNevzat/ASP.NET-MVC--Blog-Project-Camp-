using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail cannot be empty");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject Cannot be Empty ");
            RuleFor(x => x.UserSurname).NotEmpty().WithMessage("Surname Cannot be Empty");
            RuleFor(x => x.Message).MaximumLength(200).WithMessage("Message must be lower than 200 charecters");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Subject must be more than 5 charecters");
        }
    }
}
