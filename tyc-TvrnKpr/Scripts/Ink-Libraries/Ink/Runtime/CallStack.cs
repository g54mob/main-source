using System.Collections.Generic;

namespace Ink.Runtime
{
	public class CallStack
	{
		public class Element
		{
			public Pointer currentPointer;

			public bool inExpressionEvaluation;

			public Dictionary<string, Object> temporaryVariables;

			public PushPopType type;

			public int evaluationStackHeightWhenPushed;

			public int functionStartInOuputStream;

			public Element(PushPopType type, Pointer pointer, bool inExpressionEvaluation = false)
			{
			}

			public Element Copy()
			{
				return null;
			}
		}

		public class Thread
		{
			public List<Element> callstack;

			public int threadIndex;

			public Pointer previousPointer;

			public Thread()
			{
			}

			public Thread(Dictionary<string, object> jThreadObj, Story storyContext)
			{
			}

			public Thread Copy()
			{
				return null;
			}

			public void WriteJson(SimpleJson.Writer writer)
			{
			}
		}

		private List<Thread> _threads;

		private int _threadCounter;

		private Pointer _startOfRoot;

		public List<Element> elements => null;

		public int depth => 0;

		public Element currentElement => null;

		public int currentElementIndex => 0;

		public Thread currentThread
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool canPop => false;

		public bool canPopThread => false;

		public bool elementIsEvaluateFromGame => false;

		private List<Element> callStack => null;

		public string callStackTrace => null;

		public CallStack(Story storyContext)
		{
		}

		public CallStack(CallStack toCopy)
		{
		}

		public void Reset()
		{
		}

		public void SetJsonToken(Dictionary<string, object> jObject, Story storyContext)
		{
		}

		public void WriteJson(SimpleJson.Writer w)
		{
		}

		public void PushThread()
		{
		}

		public Thread ForkThread()
		{
			return null;
		}

		public void PopThread()
		{
		}

		public void Push(PushPopType type, int externalEvaluationStackHeight = 0, int outputStreamLengthWithPushed = 0)
		{
		}

		public bool CanPop(PushPopType? type = null)
		{
			return false;
		}

		public void Pop(PushPopType? type = null)
		{
		}

		public Object GetTemporaryVariableWithName(string name, int contextIndex = -1)
		{
			return null;
		}

		public void SetTemporaryVariable(string name, Object value, bool declareNew, int contextIndex = -1)
		{
		}

		public int ContextForVariableNamed(string name)
		{
			return 0;
		}

		public Thread ThreadWithIndex(int index)
		{
			return null;
		}
	}
}
