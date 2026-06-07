using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback allows you to set global properties on your shader, or enable/disable keywords.")]
	[FeedbackPath("Renderer/Shader Global")]
	[AddComponentMenu(null)]
	public class MMFeedbackShaderGlobal : MMFeedback
	{
		public enum Modes
		{
			SetGlobalColor = 0,
			SetGlobalFloat = 1,
			SetGlobalInt = 2,
			SetGlobalMatrix = 3,
			SetGlobalTexture = 4,
			SetGlobalVector = 5,
			EnableKeyword = 6,
			DisableKeyword = 7,
			WarmupAllShaders = 8
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Shader Global")]
		public Modes Mode;

		[Tooltip("the name of the global property")]
		[MMFEnumCondition("Mode", new int[] { 0, 1, 2, 3, 4, 5 })]
		public string PropertyName;

		[Tooltip("the name ID of the property retrieved by Shader.PropertyToID")]
		[MMFEnumCondition("Mode", new int[] { 0, 1, 2, 3, 4, 5 })]
		public int PropertyNameID;

		[Tooltip("a global color property for all shaders")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Color GlobalColor;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("a global float property for all shaders")]
		public float GlobalFloat;

		[Tooltip("a global int property for all shaders")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public int GlobalInt;

		[Tooltip("a global matrix property for all shaders")]
		[MMFEnumCondition("Mode", new int[] { 3 })]
		public Matrix4x4 GlobalMatrix;

		[Tooltip("a global texture property for all shaders")]
		[MMFEnumCondition("Mode", new int[] { 4 })]
		public RenderTexture GlobalTexture;

		[Tooltip("a global vector property for all shaders")]
		[MMFEnumCondition("Mode", new int[] { 5 })]
		public Vector4 GlobalVector;

		[Tooltip("a global shader keyword")]
		[MMFEnumCondition("Mode", new int[] { 6, 7 })]
		public string Keyword;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
