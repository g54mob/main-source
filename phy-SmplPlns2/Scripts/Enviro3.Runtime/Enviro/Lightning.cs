using System.Collections;
using UnityEngine;

namespace Enviro
{
	public class Lightning : MonoBehaviour, ILightningEffect
	{
		public float flashIntensity = 50f;

		public Vector3 target;

		private LineRenderer lineRend;

		public Light myLight;

		public Material planeMat;

		public int arcs = 20;

		public float arcLength = 100f;

		public float arcVariation = 1f;

		public float inaccuracy = 0.5f;

		public int splits = 4;

		public Vector3 toTarget;

		private bool fadeOut;

		private float fadeTimer;

		public void CastBolt(Vector3 origin, Vector3 target)
		{
			base.transform.position = origin;
			this.target = target;
			CastBolt();
		}

		private void OnEnable()
		{
			lineRend = base.gameObject.GetComponent<LineRenderer>();
		}

		private IEnumerator CreateLightningBolt()
		{
			myLight.enabled = false;
			lineRend.widthMultiplier = 10f;
			planeMat.SetFloat("_Intensity", 1f);
			lineRend.SetPosition(0, base.transform.position);
			lineRend.positionCount = 2;
			lineRend.SetPosition(1, base.transform.position);
			Vector3 lastPoint = base.transform.position;
			float num = Vector3.Distance(base.transform.position, target);
			float arcDist = num / (float)arcs;
			for (int i = 1; i < arcs; i++)
			{
				planeMat.SetFloat("_Intensity", Random.Range(0f, 2f));
				lineRend.positionCount = i + 1;
				Vector3 newVector = target - lastPoint;
				newVector.Normalize();
				Vector3 vector = Randomize(newVector, inaccuracy);
				vector *= Random.Range(arcLength * arcVariation, arcLength) * arcDist;
				vector += lastPoint;
				lineRend.SetPosition(i, vector);
				if (i < arcs - 2)
				{
					for (int j = 0; j <= splits; j++)
					{
						StartCoroutine(CreateSplit(vector, target));
					}
				}
				lastPoint = vector;
				yield return new WaitForSeconds(Random.Range(0.001f, 0.005f));
			}
			lineRend.SetPosition(arcs - 1, target);
			if (EnviroManager.instance.Camera != null)
			{
				myLight.transform.position = target;
			}
			myLight.transform.LookAt(EnviroManager.instance.Camera.transform.position, Vector3.up);
			lineRend.material.SetFloat("_Intensity", flashIntensity);
			planeMat.SetFloat("_Intensity", 20f);
			myLight.enabled = true;
			yield return new WaitForSeconds(Random.Range(0.025f, 0.035f));
			lineRend.material.SetFloat("_Intensity", 1f);
			planeMat.SetFloat("_Intensity", 1f);
			myLight.enabled = false;
			yield return new WaitForSeconds(Random.Range(0.025f, 0.035f));
			lineRend.material.SetFloat("_Intensity", flashIntensity);
			planeMat.SetFloat("_Intensity", 20f);
			myLight.enabled = true;
			yield return new WaitForSeconds(Random.Range(0.025f, 0.035f));
			lineRend.material.SetFloat("_Intensity", 1f);
			planeMat.SetFloat("_Intensity", 1f);
			myLight.enabled = false;
			yield return new WaitForSeconds(Random.Range(0.025f, 0.035f));
			lineRend.material.SetFloat("_Intensity", flashIntensity);
			planeMat.SetFloat("_Intensity", 0f);
			myLight.enabled = true;
			yield return new WaitForSeconds(Random.Range(0.025f, 0.035f));
			myLight.enabled = false;
			fadeTimer = 50f;
			fadeOut = true;
		}

		private IEnumerator CreateSplit(Vector3 pos, Vector3 targetP)
		{
			GameObject split = new GameObject();
			split.transform.SetParent(base.transform);
			split.transform.position = pos;
			LineRenderer splitRenderer = split.AddComponent<LineRenderer>();
			splitRenderer.material = lineRend.material;
			splitRenderer.positionCount = 2;
			splitRenderer.SetPosition(0, split.transform.position);
			splitRenderer.SetPosition(1, split.transform.position);
			toTarget = targetP - pos;
			toTarget = Vector3.Normalize(toTarget);
			new Vector3(toTarget.x, toTarget.y, toTarget.z * 0.1f);
			Vector3 targetPos = Random.insideUnitSphere * 500f + pos + toTarget * 500f;
			Vector3 lastPoint = split.transform.position;
			float num = Vector3.Distance(split.transform.position, targetPos);
			float arcDist = num / 7f;
			for (int i = 1; i < 8; i++)
			{
				splitRenderer.positionCount = i + 1;
				Vector3 newVector = targetPos - lastPoint;
				newVector.Normalize();
				Vector3 vector = Randomize(newVector, inaccuracy);
				vector *= Random.Range(1.5f, 1f) * arcDist;
				vector += lastPoint;
				splitRenderer.SetPosition(i, vector);
				lastPoint = vector;
				yield return new WaitForSeconds(Random.Range(0.004f, 0.006f));
			}
			splitRenderer.SetPosition(7, targetPos);
			yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
			Object.DestroyImmediate(split);
		}

		public void CastBolt()
		{
			lineRend.positionCount = 1;
			StartCoroutine(CreateLightningBolt());
		}

		private Vector3 Randomize(Vector3 newVector, float devation)
		{
			newVector += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * devation;
			newVector.Normalize();
			return newVector;
		}

		private void Update()
		{
			if (fadeOut)
			{
				fadeTimer = Mathf.Lerp(fadeTimer, 0f, 10f * Time.deltaTime);
				lineRend.material.SetFloat("_Intensity", fadeTimer);
				if (fadeTimer <= 1f)
				{
					lineRend.positionCount = 1;
					fadeOut = false;
					Object.DestroyImmediate(base.gameObject);
				}
			}
		}
	}
}
