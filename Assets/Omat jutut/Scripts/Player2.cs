using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private float horisontaalinenPyorinta = 0;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //perusliikkuminen
        CharacterController hahmokontrolleri = GetComponent<CharacterController>();

        //eteen ja sivuille liikkuminen
        float horizontal = Input.GetAxis("Horizontal") * 5; //nuolin‰pp‰imet
        float vertical = Input.GetAxis("Vertical") * 5; //nuolin‰pp‰imet
        Vector3 nopeus = new Vector3(horizontal, 0, vertical); //kuinka paljon nuolin‰pp‰imi‰ on painettu

        //k‰‰ntyminen hiirell‰
        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3; //lis‰t‰‰n hiiren liikkuminen k‰‰ntymiseen
        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0); //pyˆrii y-akselin ymp‰ri
        nopeus = transform.rotation * nopeus; //kerrotaan nopeus k‰‰ntymisell‰

        //komento, jolla lopulta liikutaan (t‰m‰ pit‰‰ olla viimeisen‰)
        hahmokontrolleri.Move(nopeus * Time.deltaTime);

        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("Walk", true);
        }
        else 
        {
            anim.SetBool("Walk", false);
        }
    }
}
