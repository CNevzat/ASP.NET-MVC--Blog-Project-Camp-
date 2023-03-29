using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Writeer Name Cannot be Empty ");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Writer Surname Cannot be Empty");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Writer About Cannot be Empty");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Writer Surname must be more than 2 charecters");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Writer Surname must be lower than 50 charecters");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Writer Title Cannot be Empty");
        }
    }
}
