using UnityEngine;

public class dver : MonoBehaviour
{
	public float tv;

	public float max;

	public float min;

	public float rot;

	public float A;

	public float y;

	public float slmin;

	public float slmax;

	public AudioClip[] aud;

	public AudioClip sl;

	public AudioClip raud;

	private bool a;

	private bool st;

	public bool slamm;

	public bool inv;

	public bool r;

	private int w;

	public Animator ruchka;

	private void Start()
	{
		rot = base.transform.eulerAngles.x;
	}

	private void FixedUpdate()
	{
		if (w > 10)
		{
			y = base.transform.eulerAngles.y;
			A = Mathf.Abs(Mathf.Abs(rot) - Mathf.Abs(base.transform.eulerAngles.y));
			if (A > 0.5f)
			{
				if (inv)
				{
					if (base.transform.eulerAngles.y < slmax)
					{
						slamm = true;
					}
					if (base.transform.eulerAngles.y > slmin && !r && raud != null)
					{
						st = false;
						r = true;
						ruchka.SetTrigger("tr");
						base.gameObject.GetComponent<AudioSource>().clip = raud;
						base.gameObject.GetComponent<AudioSource>().Play();
					}
				}
				else
				{
					if (base.transform.eulerAngles.y > slmax)
					{
						slamm = true;
					}
					if (base.transform.eulerAngles.y < slmin && !r && raud != null)
					{
						st = false;
						r = true;
						ruchka.SetTrigger("tr");
						base.gameObject.GetComponent<AudioSource>().clip = raud;
						base.gameObject.GetComponent<AudioSource>().Play();
					}
				}
				if (!base.gameObject.GetComponent<AudioSource>().isPlaying && st && aud.Length != 0)
				{
					st = false;
					base.gameObject.GetComponent<AudioSource>().clip = aud[Random.Range(0, aud.Length)];
					base.gameObject.GetComponent<AudioSource>().Play();
				}
			}
			else
			{
				st = true;
				if (inv)
				{
					if (base.transform.eulerAngles.y > slmin)
					{
						r = false;
					}
					if (base.transform.eulerAngles.y > slmin && slamm)
					{
						slamm = false;
						base.gameObject.GetComponent<AudioSource>().clip = sl;
						base.gameObject.GetComponent<AudioSource>().Play();
					}
				}
				else
				{
					if (base.transform.eulerAngles.y < slmin)
					{
						r = false;
					}
					if (base.transform.eulerAngles.y < slmin && slamm)
					{
						slamm = false;
						base.gameObject.GetComponent<AudioSource>().clip = sl;
						base.gameObject.GetComponent<AudioSource>().Play();
					}
				}
				if (!(base.gameObject.GetComponent<AudioSource>().clip == sl) || !base.gameObject.GetComponent<AudioSource>().isPlaying)
				{
					base.gameObject.GetComponent<AudioSource>().Stop();
				}
			}
			rot = base.transform.eulerAngles.y;
		}
		w++;
	}

	public void use()
	{
		if (base.transform.eulerAngles.y < max && base.transform.eulerAngles.y > min)
		{
			GetComponent<Rigidbody>().AddTorque(Vector3.up * tv);
		}
		else
		{
			GetComponent<Rigidbody>().AddTorque(Vector3.up * (0f - tv));
		}
	}
}
