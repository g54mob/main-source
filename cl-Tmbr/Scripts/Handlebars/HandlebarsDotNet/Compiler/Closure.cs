using HandlebarsDotNet.Decorators;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler
{
	public sealed class Closure
	{
		public readonly PathInfo PI0;

		public readonly PathInfo PI1;

		public readonly PathInfo PI2;

		public readonly PathInfo PI3;

		public readonly PathInfo[] PIA;

		public readonly Ref<IHelperDescriptor<HelperOptions>> HD0;

		public readonly Ref<IHelperDescriptor<HelperOptions>> HD1;

		public readonly Ref<IHelperDescriptor<HelperOptions>> HD2;

		public readonly Ref<IHelperDescriptor<HelperOptions>> HD3;

		public readonly Ref<IHelperDescriptor<HelperOptions>>[] HDA;

		public readonly Ref<IHelperDescriptor<BlockHelperOptions>> BHD0;

		public readonly Ref<IHelperDescriptor<BlockHelperOptions>> BHD1;

		public readonly Ref<IHelperDescriptor<BlockHelperOptions>> BHD2;

		public readonly Ref<IHelperDescriptor<BlockHelperOptions>> BHD3;

		public readonly Ref<IHelperDescriptor<BlockHelperOptions>>[] BHDA;

		public readonly Ref<IDecoratorDescriptor<DecoratorOptions>> DD0;

		public readonly Ref<IDecoratorDescriptor<DecoratorOptions>> DD1;

		public readonly Ref<IDecoratorDescriptor<DecoratorOptions>> DD2;

		public readonly Ref<IDecoratorDescriptor<DecoratorOptions>> DD3;

		public readonly Ref<IDecoratorDescriptor<DecoratorOptions>>[] DDA;

		public readonly Ref<IDecoratorDescriptor<BlockDecoratorOptions>> BDD0;

		public readonly Ref<IDecoratorDescriptor<BlockDecoratorOptions>> BDD1;

		public readonly Ref<IDecoratorDescriptor<BlockDecoratorOptions>> BDD2;

		public readonly Ref<IDecoratorDescriptor<BlockDecoratorOptions>> BDD3;

		public readonly Ref<IDecoratorDescriptor<BlockDecoratorOptions>>[] BDDA;

		public readonly TemplateDelegate TD0;

		public readonly TemplateDelegate TD1;

		public readonly TemplateDelegate TD2;

		public readonly TemplateDelegate TD3;

		public readonly TemplateDelegate[] TDA;

		public readonly DecoratorDelegate DDD0;

		public readonly DecoratorDelegate DDD1;

		public readonly DecoratorDelegate DDD2;

		public readonly DecoratorDelegate DDD3;

		public readonly DecoratorDelegate[] DDDA;

		public readonly ChainSegment[] BP0;

		public readonly ChainSegment[][] BPA;

		public readonly object[] A;

		internal Closure(PathInfo pi0, PathInfo pi1, PathInfo pi2, PathInfo pi3, PathInfo[] pia, Ref<IHelperDescriptor<HelperOptions>> hd0, Ref<IHelperDescriptor<HelperOptions>> hd1, Ref<IHelperDescriptor<HelperOptions>> hd2, Ref<IHelperDescriptor<HelperOptions>> hd3, Ref<IHelperDescriptor<HelperOptions>>[] hda, Ref<IHelperDescriptor<BlockHelperOptions>> bhd0, Ref<IHelperDescriptor<BlockHelperOptions>> bhd1, Ref<IHelperDescriptor<BlockHelperOptions>> bhd2, Ref<IHelperDescriptor<BlockHelperOptions>> bhd3, Ref<IHelperDescriptor<BlockHelperOptions>>[] bhda, TemplateDelegate td0, TemplateDelegate td1, TemplateDelegate td2, TemplateDelegate td3, TemplateDelegate[] tda, ChainSegment[] bp0, ChainSegment[][] bpa, Ref<IDecoratorDescriptor<DecoratorOptions>> dd0, Ref<IDecoratorDescriptor<DecoratorOptions>> dd1, Ref<IDecoratorDescriptor<DecoratorOptions>> dd2, Ref<IDecoratorDescriptor<DecoratorOptions>> dd3, Ref<IDecoratorDescriptor<DecoratorOptions>>[] dda, Ref<IDecoratorDescriptor<BlockDecoratorOptions>> bdd0, Ref<IDecoratorDescriptor<BlockDecoratorOptions>> bdd1, Ref<IDecoratorDescriptor<BlockDecoratorOptions>> bdd2, Ref<IDecoratorDescriptor<BlockDecoratorOptions>> bdd3, Ref<IDecoratorDescriptor<BlockDecoratorOptions>>[] bdda, DecoratorDelegate ddd0, DecoratorDelegate ddd1, DecoratorDelegate ddd2, DecoratorDelegate ddd3, DecoratorDelegate[] ddda, object[] a)
		{
			PI0 = pi0;
			PI1 = pi1;
			PI2 = pi2;
			PI3 = pi3;
			PIA = pia;
			HD0 = hd0;
			HD1 = hd1;
			HD2 = hd2;
			HD3 = hd3;
			HDA = hda;
			BHD0 = bhd0;
			BHD1 = bhd1;
			BHD2 = bhd2;
			BHD3 = bhd3;
			BHDA = bhda;
			TD0 = td0;
			TD1 = td1;
			TD2 = td2;
			TD3 = td3;
			TDA = tda;
			BP0 = bp0;
			BPA = bpa;
			DD0 = dd0;
			DD1 = dd1;
			DD2 = dd2;
			DD3 = dd3;
			DDA = dda;
			BDD0 = bdd0;
			BDD1 = bdd1;
			BDD2 = bdd2;
			BDD3 = bdd3;
			BDDA = bdda;
			DDD0 = ddd0;
			DDD1 = ddd1;
			DDD2 = ddd2;
			DDD3 = ddd3;
			DDDA = ddda;
			A = a;
		}
	}
}
