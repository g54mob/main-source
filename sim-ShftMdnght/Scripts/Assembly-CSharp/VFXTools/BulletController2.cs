using System.Threading.Tasks;
using UnityEngine;

namespace VFXTools
{
	public class BulletController2 : MonoBehaviour
	{
		public Transform rotationCenter;

		public float rotationSpeed = 100f;

		public float movementSpeed = 10f;

		public float delayTime;

		private bool isPlay;

		private void Start()
		{
			SetPlay(play: true);
		}

		private async void SetPlay(bool play)
		{
			await Task.Delay((int)(delayTime * 1000f));
			isPlay = play;
		}

		private void Update()
		{
			if (Input.GetKeyUp(KeyCode.Space))
			{
				isPlay = !isPlay;
			}
			if (isPlay)
			{
				Quaternion to = Quaternion.LookRotation(rotationCenter.position - base.transform.position);
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, rotationSpeed * Time.deltaTime);
				base.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
			}
		}
	}
}
