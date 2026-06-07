using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public abstract class Object
	{
		public delegate bool FindQueryFunc<T>(T obj);

		private DebugMetadata _debugMetadata;

		private Ink.Runtime.Object _runtimeObject;

		private bool _alreadyHadError;

		private bool _alreadyHadWarning;

		public DebugMetadata debugMetadata
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool hasOwnDebugMetadata => false;

		public virtual string typeName => null;

		public Object parent { get; set; }

		public List<Object> content { get; protected set; }

		public Story story => null;

		public Ink.Runtime.Object runtimeObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual Ink.Runtime.Path runtimePath => null;

		public virtual Container containerForCounting => null;

		public List<Object> ancestry => null;

		public string descriptionOfScope => null;

		public Path PathRelativeTo(Object otherObj)
		{
			return null;
		}

		public T AddContent<T>(T subContent) where T : Object
		{
			return null;
		}

		public void AddContent<T>(List<T> listContent) where T : Object
		{
		}

		public T InsertContent<T>(int index, T subContent) where T : Object
		{
			return null;
		}

		public T Find<T>(FindQueryFunc<T> queryFunc = null) where T : class
		{
			return null;
		}

		public List<T> FindAll<T>(FindQueryFunc<T> queryFunc = null) where T : class
		{
			return null;
		}

		private void FindAll<T>(FindQueryFunc<T> queryFunc, List<T> foundSoFar) where T : class
		{
		}

		public abstract Ink.Runtime.Object GenerateRuntimeObject();

		public virtual void ResolveReferences(Story context)
		{
		}

		public FlowBase ClosestFlowBase()
		{
			return null;
		}

		public virtual void Error(string message, Object source = null, bool isWarning = false)
		{
		}

		public void Warning(string message, Object source = null)
		{
		}

		public static implicit operator bool(Object obj)
		{
			return false;
		}

		public static bool operator ==(Object a, Object b)
		{
			return false;
		}

		public static bool operator !=(Object a, Object b)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
