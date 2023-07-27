using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataLayer
    {
        public object getPlayers();
        public object addPlayers(SP_PostModel postDatas);
        public object updatePlayers(SPModel updateDatas);
        public object deletePlayers(int id);
    }
}
