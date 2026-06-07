using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.VFX;

namespace VFXTools
{
	public class BulletController : MonoBehaviour
	{
		public float rotationSpeed = 100f;

		public float movementSpeed = 10f;

		public float delayTime;

		private bool isPlay;

		public float time = 1f;

		private float lastTime;

		private Vector3 startPos;

		public TowardType towardType;

		private Vector3 directionToCenter;

		private Vector3 scale;

		private VisualEffect[] vfxs;

		private TrailRenderer[] trails;

		public float maxDistance = 100f;

		private float curDistance;

		private void Start()
		{
			vfxs = GetComponentsInChildren<VisualEffect>(includeInactive: false);
			trails = GetComponentsInChildren<TrailRenderer>(includeInactive: false);
			startPos = base.transform.position;
			SetPlay(play: true);
		}

		private async void SetPlay(bool play)
		{
			isPlay = play;
		}

		private void Update()
		{
			if (Input.GetKeyUp(KeyCode.Space))
			{
				isPlay = !isPlay;
			}
			if (!isPlay)
			{
				return;
			}
			lastTime += Time.deltaTime;
			if (lastTime > time)
			{
				scale = base.transform.localScale;
				for (int i = 0; i < vfxs.Length; i++)
				{
					vfxs[i].enabled = false;
				}
				for (int j = 0; j < trails.Length; j++)
				{
					trails[j].enabled = false;
				}
				base.transform.localScale = Vector3.zero;
				base.transform.position = startPos;
				lastTime = 0f;
				curDistance = 0f;
				base.transform.localScale = scale;
				isPlay = false;
				DelayEnable();
			}
			else if (!(delayTime > lastTime) && !(curDistance > maxDistance))
			{
				directionToCenter = base.transform.forward;
				Quaternion to = Quaternion.LookRotation(directionToCenter);
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, rotationSpeed * Time.deltaTime);
				if (towardType == TowardType.Forward)
				{
					base.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
				}
				else if (towardType == TowardType.Right)
				{
					base.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
				}
				curDistance += movementSpeed * Time.deltaTime;
			}
		}

		public async void DelayEnable()
		{
			await Task.Delay(500);
			for (int i = 0; i < vfxs.Length; i++)
			{
				vfxs[i].enabled = true;
			}
			for (int j = 0; j < trails.Length; j++)
			{
				trails[j].enabled = true;
			}
			isPlay = true;
		}
	}
}
