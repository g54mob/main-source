using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Player.Toolbar.Concrete
{
	public abstract class ConcreteToolbarService<TItemData> : MonoBehaviour, jj where TItemData : class, bjg
	{
		[CompilerGenerated]
		private Action<bjg, int> qgb;

		[CompilerGenerated]
		private Action<bjg, int> qgc;

		[CompilerGenerated]
		private Action<bjg, int> qgd;

		private const int qgh = 0;

		private bdo qgi;

		[SerializeField]
		private int m_capacity;

		private jr<TItemData> qgj;

		public IEnumerable<jt<TItemData>> xap => null;

		public jt<TItemData> xaq => null;

		public IEnumerable<jt<bjg>> xag => null;

		public jt<bjg> xah => null;

		public int xai => 0;

		public int xaj => 0;

		public IEnumerable<TItemData> xar => null;

		public event Action<bjg, int> yec
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

		public event Action<bjg, int> yed
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

		public event Action<bjg, int> yee
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

		public event Action<TItemData, int> qge
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

		public event Action<TItemData, int> qgf
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

		public event Action<TItemData, int> qgg
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

		[Inject]
		private void ezp(bdo a)
		{
		}

		private void Update()
		{
		}

		public void ezz([CanBeNull] IEnumerable<TItemData> initialItemsData)
		{
		}

		private void faa()
		{
		}

		public bool fab(TItemData a)
		{
			return false;
		}

		public void fac(int a)
		{
		}

		public bool fad(TItemData a, int b)
		{
			return false;
		}

		public bool fae(int a)
		{
			return false;
		}

		protected abstract void faf();

		private void fag(TItemData a, int b)
		{
		}

		private void fah(TItemData a, int b)
		{
		}

		private void fai([CanBeNull] IEnumerable<TItemData> initialItemsData)
		{
		}

		private IEnumerable<jt<bjg>> faj()
		{
			return null;
		}

		private jt<bjg> fak()
		{
			return null;
		}
	}
}
