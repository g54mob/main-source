using UnityEngine;

namespace FractureField.UI
{
	public class CommunityButton : MonoBehaviour
	{
		[SerializeField]
		private GameObject _discordGO;

		[SerializeField]
		private GameObject _qqGO;

		public const string DiscordURL = "https://discord.gg/ksF9HefXqp";

		public const string QQURL = "https://qm.qq.com/q/69vB0EQKc0";

		private void Awake()
		{
		}

		public void Clicked()
		{
		}
	}
}
