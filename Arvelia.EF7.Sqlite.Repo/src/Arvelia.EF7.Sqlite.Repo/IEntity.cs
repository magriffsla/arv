using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arvelia.EF7.Sqlite.Repo
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
