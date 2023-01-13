using UnityEngine;
using System.Collections;

public class CustomerMover : MonoBehaviour
{
    [SerializeField] GameObject[] customers;
    [SerializeField] Transform[] points;
    [SerializeField] float speed;
    Animator anim;

    void Update()
    {
        ServeCustomer();
        speed = PlayerPrefs.GetFloat("speed");
    }

    void ServeCustomer()
    {
        if (customers[0].GetComponent<CoffeTaken>().coffeTaken)
        {
            GameObject firstCustomer = customers[0];
            for (int i = 0; i < customers.Length - 1; i++)
            {
                customers[i] = customers[i + 1];
            }
            customers[^1] = firstCustomer;
            customers[3].transform.position = points[3].transform.position;
        }

        for (int i = 0; i < customers.Length; i++)
        {
            Vector3 currentPos = customers[i].transform.position;
            Vector3 movePosition = points[i].position;

            customers[i].transform.position = Vector3.MoveTowards(currentPos, movePosition, speed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(movePosition - customers[i].transform.position - new Vector3(0, 0, .01f));
            customers[i].transform.rotation = Quaternion.Slerp(customers[i].transform.rotation, targetRotation, Time.deltaTime * speed);

            anim = customers[i].GetComponent<Animator>();
            if (customers[i].transform.position != movePosition)
            {
                anim.SetBool("moving", true);
            }
            if (customers[i].transform.position == movePosition)
            {
                anim.SetBool("moving", false);
            }
        }
    }
}