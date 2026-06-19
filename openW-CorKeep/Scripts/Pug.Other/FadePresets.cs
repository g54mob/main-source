public static class FadePresets
{
	public static readonly CameraSceneFader.FadeSettings blackToBlack = new CameraSceneFader.FadeSettings(CameraSceneFader.FadeStyle.BLACK, CameraSceneFader.FadeCurve.SMOOTH, CameraSceneFader.FadeStyle.BLACK, CameraSceneFader.FadeCurve.SMOOTH);

	public static readonly CameraSceneFader.FadeSettings circleToBlack = new CameraSceneFader.FadeSettings(CameraSceneFader.FadeStyle.CIRCLE, CameraSceneFader.FadeCurve.STRAIGHT, CameraSceneFader.FadeStyle.BLACK, CameraSceneFader.FadeCurve.SMOOTH);

	public static readonly CameraSceneFader.FadeSettings circleToCircle = new CameraSceneFader.FadeSettings(CameraSceneFader.FadeStyle.CIRCLE, CameraSceneFader.FadeCurve.STRAIGHT, CameraSceneFader.FadeStyle.CIRCLE, CameraSceneFader.FadeCurve.STRAIGHT);

	public static readonly CameraSceneFader.FadeSettings cut = new CameraSceneFader.FadeSettings(CameraSceneFader.FadeStyle.CUT, CameraSceneFader.FadeCurve.STRAIGHT, CameraSceneFader.FadeStyle.CUT, CameraSceneFader.FadeCurve.STRAIGHT);

	public static readonly CameraSceneFader.FadeSettings blackToCircle = new CameraSceneFader.FadeSettings(CameraSceneFader.FadeStyle.BLACK, CameraSceneFader.FadeCurve.SMOOTH, CameraSceneFader.FadeStyle.CIRCLE, CameraSceneFader.FadeCurve.STRAIGHT);

	public static readonly CameraSceneFader.FadeSettings circleVictoryToCircle = new CameraSceneFader.FadeSettings(CameraSceneFader.FadeStyle.CIRCLE, CameraSceneFader.FadeCurve.ANIM_CURVE_VICTORY, CameraSceneFader.FadeStyle.CIRCLE, CameraSceneFader.FadeCurve.STRAIGHT);

	public static readonly CameraSceneFader.FadeSettings circleEatenToCircle = new CameraSceneFader.FadeSettings(CameraSceneFader.FadeStyle.CIRCLE, CameraSceneFader.FadeCurve.ANIM_CURVE_EATEN, CameraSceneFader.FadeStyle.CIRCLE, CameraSceneFader.FadeCurve.STRAIGHT);

	public static readonly CameraSceneFader.FadeSettings circleButtToCircle = new CameraSceneFader.FadeSettings(CameraSceneFader.FadeStyle.CIRCLE, CameraSceneFader.FadeCurve.ANIM_CURVE_BUTTDANCE, CameraSceneFader.FadeStyle.CIRCLE, CameraSceneFader.FadeCurve.STRAIGHT);
}
