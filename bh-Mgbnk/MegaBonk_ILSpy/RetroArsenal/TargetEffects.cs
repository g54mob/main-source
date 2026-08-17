using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace RetroArsenal;

[Serializable]
public class TargetEffects
{
	public GameObject hitParticle;

	public GameObject respawnParticle;

	public List<GameObject> deathParticles;

	public AudioClip destroySound;

	public AudioClip respawnSound;

	public TargetEffects()
	{
		List<GameObject> list = new List<GameObject>();
		deathParticles = list;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
