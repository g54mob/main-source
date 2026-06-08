using System;
using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class ExhibitBuilder
	{
		public Project project;

		private static Transform _cursor;

		public List<ExhibitBuilderItem> items;

		public Transform cursor => null;

		public ExhibitBuilderConfig config => null;

		public Exhibit Bake(Project project)
		{
			return null;
		}

		public void AddBox(Action<ExhibitBuilderCall> action)
		{
		}

		public void AddCylinder(Action<ExhibitBuilderCall> action)
		{
		}

		public void Add(Action<ExhibitBuilderCall> action)
		{
		}
	}
}
