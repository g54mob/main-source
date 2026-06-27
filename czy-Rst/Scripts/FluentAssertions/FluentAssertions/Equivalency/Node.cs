using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	internal class Node : INode
	{
		private static readonly Regex MatchFirstIndex = new Regex("^\\[[0-9]+\\]$");

		private GetSubjectId subjectIdProvider;

		private string cachedSubjectId;

		private Pathway subject;

		public GetSubjectId GetSubjectId
		{
			get
			{
				return () => cachedSubjectId ?? (cachedSubjectId = subjectIdProvider());
			}
			protected init
			{
				subjectIdProvider = value;
			}
		}

		public Type Type { get; protected set; }

		public Type ParentType { get; protected set; }

		public Pathway Subject
		{
			get
			{
				return subject;
			}
			set
			{
				subject = value;
				if ((object)Expectation == null)
				{
					Expectation = value;
				}
			}
		}

		public Pathway Expectation { get; protected set; }

		public bool IsRoot
		{
			get
			{
				if (Subject.PathAndName.Length != 0)
				{
					if (RootIsCollection)
					{
						return IsFirstIndex;
					}
					return false;
				}
				return true;
			}
		}

		private bool IsFirstIndex => MatchFirstIndex.IsMatch(Subject.PathAndName);

		public bool RootIsCollection { get; protected set; }

		public int Depth => Subject.PathAndName.Count((char chr) => chr == '.');

		public void AdjustForRemappedSubject(IMember subjectMember)
		{
			if (subject.Name != subjectMember.Subject.Name)
			{
				subject.Name = subjectMember.Subject.Name;
			}
		}

		private static bool IsCollection(Type type)
		{
			if (!typeof(string).IsAssignableFrom(type))
			{
				return typeof(IEnumerable).IsAssignableFrom(type);
			}
			return false;
		}

		public static INode From<T>(GetSubjectId getSubjectId)
		{
			return new Node
			{
				subjectIdProvider = () => getSubjectId() ?? "root",
				Subject = new Pathway(string.Empty, string.Empty, (string _) => getSubjectId()),
				Type = typeof(T),
				ParentType = null,
				RootIsCollection = IsCollection(typeof(T))
			};
		}

		public static INode FromCollectionItem<T>(string index, INode parent)
		{
			Pathway.GetDescription getDescription = (string pathAndName) => parent.GetSubjectId().Combine(pathAndName);
			string name = "[" + index + "]";
			return new Node
			{
				Type = typeof(T),
				ParentType = parent.Type,
				Subject = new Pathway(parent.Subject, name, getDescription),
				Expectation = new Pathway(parent.Expectation, name, getDescription),
				GetSubjectId = parent.GetSubjectId,
				RootIsCollection = parent.RootIsCollection
			};
		}

		public static INode FromDictionaryItem<T>(object key, INode parent)
		{
			Pathway.GetDescription getDescription = (string pathAndName) => parent.GetSubjectId().Combine(pathAndName);
			string name = "[" + key?.ToString() + "]";
			return new Node
			{
				Type = typeof(T),
				ParentType = parent.Type,
				Subject = new Pathway(parent.Subject, name, getDescription),
				Expectation = new Pathway(parent.Expectation, name, getDescription),
				GetSubjectId = parent.GetSubjectId,
				RootIsCollection = parent.RootIsCollection
			};
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((Node)obj);
		}

		private bool Equals(Node other)
		{
			Type type = Type;
			string name = Subject.Name;
			string path = Subject.Path;
			Type type2 = other.Type;
			string name2 = other.Subject.Name;
			string path2 = other.Subject.Path;
			if (type == type2 && name == name2)
			{
				return path == path2;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (Type.GetHashCode() * 397 + Subject.Path.GetHashCode()) * 397 + Subject.Name.GetHashCode();
		}

		public override string ToString()
		{
			return Subject.Description;
		}
	}
}
