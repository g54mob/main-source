using System;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class EnemyDissolve : MonoBehaviour
{
	public Material dissolveMaterial;

	private float dissolveDuration = 0.3f;

	private float dissolveAmount;

	private float displaceAmount;

	private float displaceTarget = 0.15f;

	private bool isDissolving;

	public Renderer enemyRenderer;

	private MaterialPropertyBlock mpb;

	public Enemy enemy;

	public Action A_DissolveFinished;

	private void Update()
	{
		if (!isDissolving || MyTime.paused)
		{
			return;
		}
		float num = MyTime.deltaTime / dissolveDuration;
		float value = (dissolveAmount = num + dissolveAmount);
		mpb.SetFloat("_DissolveAmount", value);
		float value2 = displaceTarget * dissolveAmount;
		mpb.SetFloat("_DisplacementStrength", value2);
		enemyRenderer.Internal_SetPropertyBlockMaterialIndex(mpb, 0);
		if (!(dissolveAmount < 1f))
		{
			Action a_DissolveFinished = A_DissolveFinished;
			isDissolving = false;
			dissolveAmount = 1f;
			if (A_DissolveFinished != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v71.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public void StartDissolve()
	{
		if (!isDissolving)
		{
			isDissolving = true;
			dissolveAmount = 0f;
			Material sharedMaterial = enemyRenderer.GetSharedMaterial();
			if (sharedMaterial != dissolveMaterial)
			{
				enemyRenderer.SetMaterial(dissolveMaterial);
			}
			mpb.SetFloat("_DissolveAmount", dissolveAmount);
		}
	}

	public void Reset()
	{
		if (mpb == null)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			mpb = materialPropertyBlock;
		}
		isDissolving = false;
		dissolveAmount = 0f;
		mpb.SetFloat("_DissolveAmount", 0f);
		float value = displaceTarget * dissolveAmount;
		mpb.SetFloat("_DisplacementStrength", value);
	}
}
