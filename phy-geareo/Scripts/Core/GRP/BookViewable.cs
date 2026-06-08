using System;
using System.Runtime.CompilerServices;
using Rhizomatic.Reactive;

namespace GRP
{
	public class BookViewable : Viewable
	{
		public int position;

		public Book book;

		public event Action onNext
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onPrevious
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<int, int, float> onJump
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public BookViewable(Book book)
		{
		}

		public void Next()
		{
		}

		public void Previous()
		{
		}

		public void Jump(int value, int steps, float time)
		{
		}

		public void Jump(int value)
		{
		}
	}
}
