using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	internal interface IPropertyWrapperVariants : IPropertyWrapper
	{
		void SetKeyword(in LocalKeyword keyword, bool value);
	}
}
