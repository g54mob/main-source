using UnityEngine;

public class OVRLipSyncContextTextureFlip : MonoBehaviour
{
	public Material material;

	[Tooltip("The texture used for each viseme.")]
	[OVRNamedArray(new string[]
	{
		"sil", "PP", "FF", "TH", "DD", "kk", "CH", "SS", "nn", "RR",
		"aa", "E", "ih", "oh", "ou"
	})]
	public Texture[] Textures = new Texture[OVRLipSync.VisemeCount];

	[Range(1f, 100f)]
	[Tooltip("Smoothing of 1 will yield only the current predicted viseme,100 will yield an extremely smooth viseme response.")]
	public int smoothAmount = 70;

	private OVRLipSyncContextBase lipsyncContext;

	private OVRLipSync.Frame oldFrame = new OVRLipSync.Frame();

	private void Start()
	{
		lipsyncContext = GetComponent<OVRLipSyncContextBase>();
		if (lipsyncContext == null)
		{
			Debug.LogWarning("LipSyncContextTextureFlip.Start WARNING: No lip sync context component set to object");
		}
		else
		{
			lipsyncContext.Smoothing = smoothAmount;
		}
		if (material == null)
		{
			Debug.LogWarning("LipSyncContextTextureFlip.Start WARNING: Lip sync context texture flip has no material target to control!");
		}
	}

	private void Update()
	{
		if (lipsyncContext != null && material != null)
		{
			OVRLipSync.Frame currentPhonemeFrame = lipsyncContext.GetCurrentPhonemeFrame();
			if (currentPhonemeFrame != null)
			{
				if (lipsyncContext.provider == OVRLipSync.ContextProviders.Original)
				{
					for (int i = 0; i < currentPhonemeFrame.Visemes.Length; i++)
					{
						float num = (float)(smoothAmount - 1) / 100f;
						oldFrame.Visemes[i] = oldFrame.Visemes[i] * num + currentPhonemeFrame.Visemes[i] * (1f - num);
					}
				}
				else
				{
					oldFrame.Visemes = currentPhonemeFrame.Visemes;
				}
				SetVisemeToTexture();
			}
		}
		if (smoothAmount != lipsyncContext.Smoothing)
		{
			lipsyncContext.Smoothing = smoothAmount;
		}
	}

	private void SetVisemeToTexture()
	{
		int num = -1;
		float num2 = 0f;
		for (int i = 0; i < oldFrame.Visemes.Length; i++)
		{
			if (oldFrame.Visemes[i] > num2)
			{
				num = i;
				num2 = oldFrame.Visemes[i];
			}
		}
		if (num != -1 && num < Textures.Length)
		{
			Texture texture = Textures[num];
			if (texture != null)
			{
				material.SetTexture("_MainTex", texture);
			}
		}
	}
}
