using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ILogicLayer
    {
        public object getAll();
        public object? addPlayers(SP_PostModel postDatas);
        public object? updatePlayers(SPModel updateDatas);
        public object deletePlayers(int id);


    }
}
