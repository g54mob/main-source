using System;
using System.Collections.Generic;
using System.Text;
using Cpp2ILInjected;
using UnityEngine;

namespace RetroArsenalLib;

public class RetroVFXLibrary : MonoBehaviour
{
	public static RetroVFXLibrary GlobalAccess;

	public int TotalEffects;

	public int CurrentParticleEffectIndex;

	public int CurrentParticleEffectNum;

	public Vector3[] ParticleEffectSpawnOffsets;

	public float[] ParticleEffectLifetimes;

	public GameObject[] ParticleEffectPrefabs;

	private List<Transform> currentActivePEList;

	private StringBuilder effectNameBuilder;

	private void Awake()
	{
		GlobalAccess = this;
		GameObject[] particleEffectPrefabs = ParticleEffectPrefabs;
		Vector3[] particleEffectSpawnOffsets = ParticleEffectSpawnOffsets;
		TotalEffects = particleEffectPrefabs.Length;
		if (particleEffectSpawnOffsets.Length == particleEffectPrefabs.Length)
		{
			GameObject[] particleEffectPrefabs2 = ParticleEffectPrefabs;
			if (particleEffectPrefabs2.Length == particleEffectPrefabs.Length)
			{
				goto IL_0081;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		goto IL_0081;
		IL_0081:
		UpdateEffectNameString();
	}

	public string GetCurrentPENameString()
	{
		if (effectNameBuilder != null)
		{
			return effectNameBuilder.ToString();
		}
		return (string)(object)new NullReferenceException();
	}

	public void PreviousParticleEffect()
	{
		//IL_0016: Expected O, but got I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected I4, but got Unknown
		DestroyLoopingParticleEffects();
		object obj = CurrentParticleEffectIndex - 1;
		object obj2 = TotalEffects + obj;
		int currentParticleEffectIndex = obj2 % TotalEffects;
		CurrentParticleEffectIndex = currentParticleEffectIndex;
		UpdateEffectNameString();
	}

	public void NextParticleEffect()
	{
		//IL_0016: Expected O, but got I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected I4, but got Unknown
		DestroyLoopingParticleEffects();
		object obj = CurrentParticleEffectIndex + 1;
		int currentParticleEffectIndex = obj % TotalEffects;
		CurrentParticleEffectIndex = currentParticleEffectIndex;
		UpdateEffectNameString();
	}

	private unsafe void DestroyLoopingParticleEffects()
	{
		//IL_004e: Invalid comparison between F4 and I4
		//IL_016e: Expected O, but got I
		float[] particleEffectLifetimes = ParticleEffectLifetimes;
		if (ParticleEffectLifetimes != null)
		{
			int currentParticleEffectIndex = CurrentParticleEffectIndex;
			if (CurrentParticleEffectIndex >= particleEffectLifetimes.Length)
			{
				throw new IndexOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001804BCCB2h\"");
			if (particleEffectLifetimes[currentParticleEffectIndex] != 0f)
			{
				return;
			}
			if (currentActivePEList != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				UnityEngine.Object obj = default(UnityEngine.Object);
				while (enumerator.MoveNext())
				{
					if (obj != null)
					{
						if ((object)obj == null)
						{
							throw new NullReferenceException();
						}
						GameObject obj2 = ((Component)obj).gameObject;
						UnityEngine.Object.Destroy(obj2);
					}
				}
				((List<Transform>.Enumerator*)(&enumerator))->Dispose();
				particleEffectLifetimes = (float[])(object)currentActivePEList;
				if (currentActivePEList != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v5 (System.Single[])+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Store into unknown operand: v88.Length");
					if (particleEffectLifetimes.Length > 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v5 (System.Single[])+10]");
						Array.Clear((Array)0, 0, particleEffectLifetimes.Length);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateEffectNameString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172BAD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		StringBuilder stringBuilder = effectNameBuilder.Clear();
		GameObject[] particleEffectPrefabs = ParticleEffectPrefabs;
		int currentParticleEffectIndex = CurrentParticleEffectIndex;
		string value = particleEffectPrefabs[currentParticleEffectIndex].name;
		StringBuilder stringBuilder2 = effectNameBuilder.Append(value);
		StringBuilder stringBuilder3 = effectNameBuilder.Append(" (");
		int value2 = CurrentParticleEffectIndex + 1;
		StringBuilder stringBuilder4 = effectNameBuilder.Append(value2);
		StringBuilder stringBuilder5 = effectNameBuilder.Append("/");
		StringBuilder stringBuilder6 = effectNameBuilder.Append(TotalEffects);
		StringBuilder stringBuilder7 = effectNameBuilder.Append(")");
	}

	public unsafe void SpawnParticleEffect(Vector3 positionInWorldToSpawn)
	{
		//IL_0042: Expected O, but got Ref
		//IL_0042: Expected O, but got Ref
		//IL_00d8: Invalid comparison between F4 and I4
		//IL_01dd: Invalid comparison between F4 and I4
		GameObject[] particleEffectPrefabs = ParticleEffectPrefabs;
		int currentParticleEffectIndex = CurrentParticleEffectIndex;
		object obj = default(object);
		object obj2 = default(object);
		GameObject gameObject = UnityEngine.Object.Instantiate(particleEffectPrefabs[currentParticleEffectIndex], (Vector3)(&obj), (Quaternion)(&obj2));
		GameObject[] particleEffectPrefabs2 = ParticleEffectPrefabs;
		int currentParticleEffectIndex2 = CurrentParticleEffectIndex;
		string text = particleEffectPrefabs2[currentParticleEffectIndex2].name;
		string text2 = "PE_" + text;
		gameObject.name = text2;
		float[] particleEffectLifetimes = ParticleEffectLifetimes;
		int currentParticleEffectIndex3 = CurrentParticleEffectIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804BCFB8h\"");
		if (particleEffectLifetimes[currentParticleEffectIndex3] == 0f)
		{
			List<object> list = (List<object>)(object)currentActivePEList;
			Transform transform = gameObject.transform;
			int version = list._version + 1;
			list._version = version;
			object[] items = list._items;
			if (list._size >= items.Length)
			{
				list.AddWithResize((object)transform);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				int num = default(int);
				items[num] = transform;
			}
		}
		float[] particleEffectLifetimes2 = ParticleEffectLifetimes;
		int currentParticleEffectIndex4 = CurrentParticleEffectIndex;
		bool flag = particleEffectLifetimes2[currentParticleEffectIndex4] == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804BCFD7h\"");
		if (!flag)
		{
			int currentParticleEffectIndex5 = CurrentParticleEffectIndex;
			UnityEngine.Object.Destroy(gameObject, particleEffectLifetimes2[currentParticleEffectIndex5]);
		}
	}

	public RetroVFXLibrary()
	{
		List<Transform> list = new List<Transform>();
		currentActivePEList = list;
		effectNameBuilder = new StringBuilder();
		base._002Ector();
	}
}
