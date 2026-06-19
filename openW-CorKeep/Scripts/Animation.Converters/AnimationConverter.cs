using Pug.Conversion;
using Pug.UnityExtensions;

public class AnimationConverter : SingleAuthoringComponentConverter<AnimationAuthoring>
{
	protected override void Convert(AnimationAuthoring authoring)
	{
		bool largeAnimationHistorySupport = authoring.largeAnimationHistorySupport;
		((Converter)this).EnsureHasComponent<AnimationBufferPointer>();
		((Converter)this).EnsureHasComponent<LocalAnimationBufferPointer>();
		((Converter)this).EnsureHasBuffer<AnimationBuffer>();
		int num = ((!largeAnimationHistorySupport) ? 1 : 3);
		for (int i = 0; i < num; i++)
		{
			((Converter)this).AddToBuffer<AnimationBuffer>(default(AnimationBuffer));
		}
		((Converter)this).EnsureHasBuffer<LocalAnimationBuffer>();
		int num2 = (largeAnimationHistorySupport ? 6 : 3);
		for (int j = 0; j < num2; j++)
		{
			((Converter)this).AddToBuffer<LocalAnimationBuffer>(default(LocalAnimationBuffer));
		}
		if (authoring.orientationSupport != AnimationAuthoring.OrientationSupport.None)
		{
			((Converter)this).AddComponentData<AnimationOrientationCD>(new AnimationOrientationCD
			{
				facingDirection = Direction.back,
				canOnlyFaceHorizontally = (authoring.orientationSupport == AnimationAuthoring.OrientationSupport.Horizontal),
				supportEightDirections = (authoring.orientationSupport == AnimationAuthoring.OrientationSupport.EightDirections)
			});
		}
	}
}
