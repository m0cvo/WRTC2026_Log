using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WRTC2026_Log.Models;

namespace WRTC2026_Log.Data
{
    public class WRTC2026_LogContext : DbContext
    {
        public WRTC2026_LogContext (DbContextOptions<WRTC2026_LogContext> options)
            : base(options)
        {
        }

        public DbSet<WRTC2026_Log.Models.Logbook> Logbook { get; set; } = default!;
    }
}
