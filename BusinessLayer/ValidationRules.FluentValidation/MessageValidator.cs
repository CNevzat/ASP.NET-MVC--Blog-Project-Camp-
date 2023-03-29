using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.receiverMail).NotEmpty().WithMessage("Receiver Mail Cannot be Empty ");
            RuleFor(x => x.subject).NotEmpty().WithMessage("Subject Cannot be Empty ");
            RuleFor(x => x.messageContent).NotEmpty().WithMessage("Message Cannot be Empty ");
            RuleFor(x => x.subject).MaximumLength(25).WithMessage("Subject must be lower than 25 charecters");
            RuleFor(x => x.subject).MinimumLength(5).WithMessage("Subject must be more than 5 charecters");
            RuleFor(x => x.messageContent).MaximumLength(200).WithMessage("Message must be lower than 200 charecters");
            RuleFor(x => x.messageContent).MinimumLength(5).WithMessage("Message must be more than 5 charecters");
        }   
    }
}
