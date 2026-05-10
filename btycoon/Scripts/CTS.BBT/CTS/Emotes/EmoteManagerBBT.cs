using CTS.BBT.AI;
using UnityEngine;

namespace CTS.Emotes
{
	public class EmoteManagerBBT : EmoteManager
	{
		public static void Kill(Agent agent)
		{
			if (agent.SkeletonData.TryGetBone(EBone.HeadTop, out var boneTransform))
			{
				EmoteManager.Kill(boneTransform);
			}
			EmoteManager.Kill(agent.transform);
		}

		public static void BarkAgent(Agent agent, string text, float duration = 3f)
		{
			if ((bool)agent)
			{
				Play(agent, text).SetStayDuration(duration);
			}
		}

		public static EmoteBBT Play(Agent agent, string text, EmoteBBT emote = null)
		{
			if (agent.SkeletonData.TryGetBone(EBone.HeadTop, out var boneTransform))
			{
				return EmoteManager.Play(boneTransform, text, emote).SetRoomParent(agent.RoomObject).SetHeight(0.2f);
			}
			return EmoteManager.Play(agent.transform, text, emote).SetRoomParent(agent.RoomObject).SetHeight(1.65f);
		}

		public static EmoteBBT Play(Agent agent, E_EmoteIcons icon, EmoteBBT emote = null)
		{
			return Play(agent, (int)icon, emote);
		}

		public static EmoteBBT Play(Agent agent, int icon, EmoteBBT emote = null)
		{
			if (agent.SkeletonData.TryGetBone(EBone.HeadTop, out var boneTransform))
			{
				return EmoteManager.Play(boneTransform, icon, emote).SetRoomParent(agent.RoomObject).SetHeight(0.2f);
			}
			return EmoteManager.Play(agent.transform, icon, emote).SetRoomParent(agent.RoomObject).SetHeight(1.65f);
		}

		public static EmoteBBT Play(Agent agent, Sprite sprite, EmoteBBT emote = null)
		{
			if (agent.SkeletonData.TryGetBone(EBone.HeadTop, out var boneTransform))
			{
				return EmoteManager.Play(boneTransform, sprite, emote).SetRoomParent(agent.RoomObject).SetHeight(0.2f);
			}
			return EmoteManager.Play(agent.transform, sprite, emote).SetRoomParent(agent.RoomObject).SetHeight(1.65f);
		}

		public static EmoteBBT Play(RoomObject barObject, string text, EmoteBBT emote = null)
		{
			return EmoteManager.Play(barObject.transform, text, emote).SetRoomParent(barObject);
		}

		public static EmoteBBT Play(RoomObject barObject, E_EmoteIcons icon, EmoteBBT emote = null)
		{
			return Play(barObject, (int)icon, emote);
		}

		public static EmoteBBT Play(RoomObject barObject, int icon, EmoteBBT emote = null)
		{
			return EmoteManager.Play(barObject.transform, icon, emote).SetRoomParent(barObject);
		}

		public static EmoteBBT Play(RoomObject barObject, Sprite sprite, EmoteBBT emote = null)
		{
			return EmoteManager.Play(barObject.transform, sprite, emote).SetRoomParent(barObject);
		}
	}
}
