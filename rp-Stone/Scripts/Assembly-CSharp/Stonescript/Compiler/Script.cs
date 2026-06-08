using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stonescript.Compiler
{
	public class Script
	{
		public string name;

		public DateTime modifiedTimestamp;

		public DateTime buildTimestamp;

		private string source;

		public ParseTree parseTree;

		public HashSet<Script> dependsOn = new HashSet<Script>();

		public string Source
		{
			get
			{
				return source;
			}
			set
			{
				if (!(source == value))
				{
					source = value;
					modifiedTimestamp = DateTime.UtcNow;
				}
			}
		}

		public string[] Lines
		{
			get
			{
				return source.Split('\n');
			}
			set
			{
				Source = string.Join("\n", value);
			}
		}

		public Script()
		{
		}

		public Script(string[] source, string name = null)
			: this(string.Join("\n", source), name)
		{
		}

		public Script(string source, string name = null)
		{
			this.source = source;
			if (name == null)
			{
				this.name = "anon-" + UnityEngine.Random.Range(0, int.MaxValue);
			}
			else
			{
				this.name = name;
			}
			modifiedTimestamp = DateTime.UtcNow;
		}

		public void Replace(string newSource, DateTime modified)
		{
			source = newSource;
			modifiedTimestamp = modified;
		}

		public void Replace(string[] newSource, DateTime modified)
		{
			Lines = newSource;
			modifiedTimestamp = modified;
		}

		public HashSet<Script> GetAllDependencies()
		{
			HashSet<Script> hashSet = new HashSet<Script>();
			GetAllDependencies(hashSet);
			return hashSet;
		}

		private void GetAllDependencies(HashSet<Script> deps)
		{
			foreach (Script item in dependsOn)
			{
				if (!deps.Contains(item))
				{
					deps.Add(item);
					item.GetAllDependencies(deps);
				}
			}
		}
	}
}
