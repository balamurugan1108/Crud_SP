using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class LogicLayer:ILogicLayer
    {
        private readonly IDataLayer _datalayer;
        public LogicLayer(IDataLayer datalayer)
        {
                _datalayer = datalayer; 
        }

        public object getAll()
        {
            return _datalayer.getPlayers();
        }
        public object? addPlayers(SP_PostModel postDatas)
        {
            return _datalayer.addPlayers(postDatas);
        }
        public object? updatePlayers(SPModel updateDatas)
        {
            return _datalayer.updatePlayers(updateDatas);
        }
        public object deletePlayers(int id)
        {
            return _datalayer.deletePlayers(id);
        }
    }
}
