using System;
namespace NoteProject.Models
{
	public class NoteCreateModel
	{
		public NoteCreateModel()
		{
		}
		public int ID { get; set; }

		public int ParentID { get; set; }

		public string NoteDesc { get; set; }
	}
}

