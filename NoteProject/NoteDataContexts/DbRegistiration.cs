using System;
using Microsoft.EntityFrameworkCore;

namespace NoteProject.NoteDataContexts
{
	public static class DbRegistiration
	{
        public static void AddContext(this IServiceCollection services,string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            services.AddDbContext<NoteDataContext>(options =>
            {
                options.UseMySql(
                    connectionString,
                    serverVersion,
                    options => options.EnableRetryOnFailure());
            });
        }
    }
}

