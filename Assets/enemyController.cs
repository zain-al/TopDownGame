using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{

    public Animator enemyanim;
    public float speed;
    public Transform target;
	public BoxCollider weaponcollider;
	public Image health;
    bool isreached;
    bool isdead;
	// Start is called before the first frame update
	void Start()
    {
        isreached = false;
        isdead = false;
		target = GameObject.FindWithTag("Player").transform;
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			if (!isdead)
			{
				isreached = true;
				enemyanim.SetTrigger("attack");
				enemyanim.ResetTrigger("walk");
				weaponcollider.enabled = true;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			isreached = false;
			enemyanim.SetTrigger("walk");
			enemyanim.ResetTrigger("attack");
			weaponcollider.enabled = false;

		}
	}

	public void DamageCounter()
	{
		health.fillAmount -= .4f;
		if (health.fillAmount <= 0)
		{
			isdead = true;
			enemyanim.ResetTrigger("walk");
			enemyanim.ResetTrigger("attack");
			enemyanim.SetTrigger("death");
			StartCoroutine(calldestroy());
		}
	}

	IEnumerator calldestroy()
	{
		yield return new WaitForSeconds(3f);
		Destroy(this.gameObject);
	}

	// Update is called once per frame
	void Update()
	{
		if (!isreached && target!=null)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
		}
        transform.LookAt(target);
    }
}
