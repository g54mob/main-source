using System.Collections.Generic;

namespace App.Data
{
	public class ProjectPartsSet
	{
		public HashSet<string> PredefinedEvents = new HashSet<string>();

		public HashSet<string> PredefinedProjects = new HashSet<string>();

		public HashSet<string> Titles = new HashSet<string>();

		public HashSet<string> Genres = new HashSet<string>();

		public HashSet<string> Authors = new HashSet<string>();

		public HashSet<string> MailTemplates = new HashSet<string>();

		public HashSet<string> AlgoProjects = new HashSet<string>();
	}
}
