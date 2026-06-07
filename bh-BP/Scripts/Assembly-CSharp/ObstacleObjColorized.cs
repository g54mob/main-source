using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjColorized : ObstacleObj
{
	public List<Color> VFXColorList;

	public ParticleSystem.MinMaxGradient[] DefaultParticleColor;

	public Dictionary<string, HDRColor>[] DefaultMatColors;

	public ParticleSystemRenderer[] ColorizedParticles;

	public ParticleSystem[] Particles;

	public MeshRenderer[] Meshes;

	public HeroInfo OwnerInf;

	public override void Init(BallObj b)
	{
	}
}
