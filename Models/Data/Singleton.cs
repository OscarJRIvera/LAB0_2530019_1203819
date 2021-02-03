using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB0_2530019_1203819.Models.Data
{
    public sealed class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public List<ClientModel> ClientList;
        private Singleton()
        {
            ClientList = new List<ClientModel>();
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
        public List<ClientModel> SortName()
        {
            List<ClientModel> copy = new List<ClientModel>(ClientList);
            for (int i = 0; i < copy.Count - 1; i++)
            {
                for (int j = i + 1; j < copy.Count; j++)
                {
                    if(copy[i].Name.CompareTo(copy[j].Name) > 0)
                    {
                        ClientModel tmp = copy[i];
                        copy[i] = copy[j];
                        copy[j] = tmp;
                    }
                }
            }
            return copy;
        }
        public List<ClientModel> SortLastName()
        {
            List<ClientModel> copyLastName = new List<ClientModel>(ClientList);
            for (int i = 0; i < copyLastName.Count - 1; i++)
            {
                for (int j = i + 1; j < copyLastName.Count; j++)
                {
                    if (copyLastName[i].Name.CompareTo(copyLastName[j].Name) > 0)
                    {
                        ClientModel tmp = copyLastName[i];
                        copyLastName[i] = copyLastName[j];
                        copyLastName[j] = tmp;
                    }
                }
            }
            return copyLastName;
        }
    }

}
