using MariemProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariemProject.Services
{
    public interface ICarsServices
    {
        bool IsCarAvailable(int carID);
    }
}
