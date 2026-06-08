using System;

namespace Jobberwocky.TriangleNet
{
	public class Configuration
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<IPredicates> _003C_003E9__0_0;

			public static Func<TrianglePool> _003C_003E9__0_1;

			internal IPredicates _003C_002Ector_003Eb__0_0()
			{
				return RobustPredicates.Default;
			}

			internal TrianglePool _003C_002Ector_003Eb__0_1()
			{
				return new TrianglePool();
			}
		}

		private Func<IPredicates> _003CPredicates_003Ek__BackingField;

		private Func<TrianglePool> _003CTrianglePool_003Ek__BackingField;

		public Func<IPredicates> Predicates
		{
			get
			{
				return _003CPredicates_003Ek__BackingField;
			}
			set
			{
				_003CPredicates_003Ek__BackingField = value;
			}
		}

		public Func<TrianglePool> TrianglePool
		{
			get
			{
				return _003CTrianglePool_003Ek__BackingField;
			}
			set
			{
				_003CTrianglePool_003Ek__BackingField = value;
			}
		}

		public Configuration()
			: this(() => RobustPredicates.Default, () => new TrianglePool())
		{
		}

		public Configuration(Func<IPredicates> predicates, Func<TrianglePool> trianglePool)
		{
			Predicates = predicates;
			TrianglePool = trianglePool;
		}
	}
}
