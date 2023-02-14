using System;
using Microsoft.EntityFrameworkCore;

namespace NoteProject.Models
{
	public class NoteModel
	{
		public NoteModel()
		{
		}
		public int ID { get; set; }

		public string NoteDesc { get; set; }

		public int? ParentNoteID { get; set; }
		public NoteModel ParentNote { get; set; }

		public ICollection<NoteModel> ChildNotes { get; set; }
	}
}

