using System.Diagnostics;
using Libs;

namespace Tgs
{
	public class TgsSpecial : SingletonMonoBehaviour<TgsSpecial>
	{
		private InputActionController input;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		[Conditional("SHOW_VER")]
		public void Reset()
		{
		}

		[Conditional("UNITY_STANDALONE_WIN")]
		public void Reboot()
		{
		}
	}
}
