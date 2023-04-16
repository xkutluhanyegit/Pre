using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant.Messages;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PersonelShiftManager : IPersonelShiftService
    {
        IPersonelShiftDal _personelShiftDal;
        public PersonelShiftManager(IPersonelShiftDal personelShiftDal)
        {
            _personelShiftDal = personelShiftDal;
        }
        public IResult Add(Personelshift personelShift)
        {
            _personelShiftDal.Add(personelShift);
            return new SuccessResult(Messages.AddedSuccessMessage);
        }
    }
}