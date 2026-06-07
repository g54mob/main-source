using UnityEngine;

public class AnimEvent_ParticleCtrl : MonoBehaviour
{
	[Header("- Anim_PlayParticleAtTransform(): 在指定位置播放Particle")]
	[Header("- Anim_SetParticleOn(): 打開Particle")]
	[Header("- Anim_SetParticleOff(): 關閉Particle")]
	[Header("- Anim_PlayParticle(): 原地開始播放Particle")]
	[Header("- Anim_StopParticleAndClear(): 停止播放Particle 並且清除已經放出的粒子")]
	[Header("- Anim_StopParticleNoClear(): 停止播放Particle 不清除已經放出的粒子")]
	[TextArea(5, 10)]
	public string note;

	[Header("指定Particle物件")]
	public GameObject[] obj_particle;

	[Header("指定Particle播放時要移到哪個物件的位置")]
	public GameObject[] obj_transform;

	public void Anim_SetParticleOn(int index)
	{
	}

	public void Anim_SetParticleOff(int index)
	{
	}

	public void Anim_PlayParticle(int index)
	{
	}

	public void Anim_StopParticleAndClear(int index)
	{
	}

	public void Anim_StopParticleNoClear(int index)
	{
	}

	public void Anim_PlayParticleAtTransform(int index)
	{
	}
}
