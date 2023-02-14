using System;
using Microsoft.EntityFrameworkCore;
using NoteProject.Models;

namespace NoteProject.NoteDataContexts
{
	public class NoteDataContext:DbContext
	{
		public NoteDataContext(DbContextOptions options):base(options)
		{
		}
		public DbSet<NoteModel> Notes { get; set; }
	}
}

