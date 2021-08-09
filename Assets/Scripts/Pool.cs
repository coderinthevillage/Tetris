using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pool : MonoBehaviour
{
    public GameObject Block;
    private List<GameObject> pool = new List<GameObject>();
    private List<GameObject> pool_f = new List<GameObject>();
    public bool is_Delete = false;
    public bool is_Down = false;
    int stroka_delete = -1;
    public GameObject Stick;
    public GameObject L;
    public GameObject No_L;
    public GameObject Piramida;
    public GameObject Angle_L;
    public GameObject Angle_R;
    public GameObject Aquare;
    int kol_square = 0;
    int kol_stick = 0;
    int kol_angle_l = 0;
    int kol_angle_r = 0;
    int kol_L = 0;
    int kol_No_L = 0;
    int kol_Piramida = 0;

    public GameObject kol_square_t;
    public GameObject kol_stick_t;
    public GameObject kol_angle_l_t;
    public GameObject kol_angle_r_t;
    public GameObject kol_L_t;
    public GameObject kol_No_L_t;
    public GameObject kol_Piramida_t;

    public int[,] map = {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }
    };

    void Start()
    {
        Color new_color = new Color(Random.Range(0.5f, 0.8f), Random.Range(0.5f, 0.8f), Random.Range(0.5f, 0.8f), 1f);

        var pr_f_1 = Instantiate(Stick);
        pr_f_1.GetComponent<SpriteRenderer>().color = new_color;
        pr_f_1.SetActive(false);
        pool_f.Add(pr_f_1);

        var pr_f_2 = Instantiate(L);
        pr_f_2.GetComponent<SpriteRenderer>().color = new_color;
        pr_f_2.SetActive(false);
        pool_f.Add(pr_f_2);

        var pr_f_3 = Instantiate(No_L);
        pr_f_3.GetComponent<SpriteRenderer>().color = new_color;
        pr_f_3.SetActive(false);
        pool_f.Add(pr_f_3);

        var pr_f_4 = Instantiate(Piramida);
        pr_f_4.GetComponent<SpriteRenderer>().color = new_color;
        pr_f_4.SetActive(false);
        pool_f.Add(pr_f_4);

        var pr_f_5 = Instantiate(Angle_L);
        pr_f_5.GetComponent<SpriteRenderer>().color = new_color;
        pr_f_5.SetActive(false);
        pool_f.Add(pr_f_5);

        var pr_f_6 = Instantiate(Angle_R);
        pr_f_6.GetComponent<SpriteRenderer>().color = new_color;
        pr_f_6.SetActive(false);
        pool_f.Add(pr_f_6);

        var pr_f_7 = Instantiate(Aquare);
        pr_f_7.GetComponent<SpriteRenderer>().color = new_color;
        pr_f_7.SetActive(false);
        pool_f.Add(pr_f_7);

        float x_n = -1.8f;
        float y_n = 3.0f;
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var pr_Block = Instantiate(Block);
                pr_Block.GetComponent<SpriteRenderer>().color = new_color;
                pr_Block.transform.position = new Vector2(x_n, y_n);
                pr_Block.SetActive(true);
                pool.Add(pr_Block);
                x_n += 0.4f;
            }
            y_n = y_n - 0.4f;
            x_n = -1.8f;
        }
        Draw();

    }

    void Update()
    {
        kol_square_t.GetComponent<Text>().text = kol_square.ToString();
        kol_stick_t.GetComponent<Text>().text = kol_stick.ToString();
        kol_angle_l_t.GetComponent<Text>().text = kol_angle_l.ToString();
        kol_angle_r_t.GetComponent<Text>().text = kol_angle_r.ToString();
        kol_L_t.GetComponent<Text>().text = kol_L.ToString();
        kol_No_L_t.GetComponent<Text>().text = kol_No_L.ToString();
        kol_Piramida_t.GetComponent<Text>().text = kol_Piramida.ToString();
        Active_element();
        Controller_f();
        Square_dno();
        Square_control();
        Stick_control();
        Stick_dno();
        Angle_L_control();
        Angle_L_dno();
        Angle_R_dno();
        Angle_R_control();
        L_dno();
        L_control();
        No_L_dno();
        No_L_control();
        Piramida_dno();
        Piramida_control();

        if (!is_Delete)
        {
            for (int i = 0; i < 20; i++)
            {
                if (i != 19)
                {
                    int kol = 0;
                    for (int j = 0; j < 10; j++) { if (map[i + 1, j] == 0) { kol += 1; } }
                    if (kol == 10)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            var pro = map[i, j];
                            map[i, j] = map[i + 1, j];
                            map[i + 1, j] = pro;
                        }
                        Draw();
                    }
                }
            }

            for (int i = 0; i < 20; i++)
            {
                int kol = 0;
                for (int j = 0; j < 10; j++) { if (map[i, j] != 0) { kol += 1; } }
                if (kol == 10)
                {
                    stroka_delete = i;
                    is_Delete = true;
                    break;
                }
            }
        }
        else
        {
            bool Flag = false;
            for (int j = 0; j < 10; j++)
            {
                float s = pool[stroka_delete * 10 + j].gameObject.transform.localScale.x;
                if (s > 0) 
                {
                    s -= 0.015f;
                    pool[stroka_delete * 10 + j].gameObject.transform.localScale = new Vector3(s, s, 1f);
                }
                else 
                {
                    pool[stroka_delete * 10 + j].gameObject.SetActive(false);
                    pool[stroka_delete * 10 + j].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                    map[stroka_delete, j] = 0;
                    Flag = true;
                }
            }
            if (Flag) { is_Delete = false; }
        }
    }

    void Draw()
    {
        int indexer_block = 0;
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (map[i, j] == 0 && pool[indexer_block].gameObject.activeInHierarchy) { pool[indexer_block].SetActive(false); }
                if (map[i, j] != 0 && !pool[indexer_block].gameObject.activeInHierarchy) { pool[indexer_block].SetActive(true); }
                indexer_block += 1;
            }
        }
    }

    void Active_element() 
    {
        bool in_active_f = false;
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy) { in_active_f = true; }
        }
        if (!in_active_f)
        {
            int variant = Random.Range(1, 8);
            string name_f = "";
            if (variant == 1) { name_f = "Angle_L(Clone)"; }
            if (variant == 2) { name_f = "Angle_R(Clone)"; }
            if (variant == 3) { name_f = "L(Clone)"; }
            if (variant == 4) { name_f = "No_L(Clone)"; }
            if (variant == 5) { name_f = "Piramida(Clone)"; }
            if (variant == 6) { name_f = "Square(Clone)"; }
            if (variant == 7) { name_f = "Stick(Clone)"; }

            for (int i = 0; i < pool_f.Count; i++)
            {
                if (pool_f[i].gameObject.name == name_f)
                {
                    if (name_f == "Angle_L(Clone)")
                    {
                        pool_f[i].gameObject.transform.position = new Vector2(0.2f, 3.6f);
                        pool_f[i].gameObject.GetComponent<Angle_L>().angle = 0;
                        pool_f[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        pool_f[i].gameObject.GetComponent<Angle_L>().speed = 0.1f;
                        pool_f[i].gameObject.GetComponent<Angle_L>().isStolknovenie = false;
                        pool_f[i].SetActive(true);
                        break;
                    }
                    if (name_f == "Angle_R(Clone)")
                    {
                        pool_f[i].gameObject.transform.position = new Vector2(0.2f, 3.6f);
                        pool_f[i].gameObject.GetComponent<Angle_R>().angle = 0;
                        pool_f[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        pool_f[i].gameObject.GetComponent<Angle_R>().speed = 0.1f;
                        pool_f[i].gameObject.GetComponent<Angle_R>().isStolknovenie = false;
                        pool_f[i].SetActive(true);
                        break;
                    }
                    if (name_f == "L(Clone)")
                    {
                        pool_f[i].gameObject.transform.position = new Vector2(0.2f, 3.6f);
                        pool_f[i].gameObject.GetComponent<L>().angle = 0;
                        pool_f[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        pool_f[i].gameObject.GetComponent<L>().speed = 0.1f;
                        pool_f[i].gameObject.GetComponent<L>().isStolknovenie = false;
                        pool_f[i].SetActive(true);
                        break;
                    }
                    if (name_f == "No_L(Clone)")
                    {
                        pool_f[i].gameObject.transform.position = new Vector2(0.2f, 3.6f);
                        pool_f[i].gameObject.GetComponent<No_L>().angle = 0;
                        pool_f[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        pool_f[i].gameObject.GetComponent<No_L>().speed = 0.1f;
                        pool_f[i].gameObject.GetComponent<No_L>().isStolknovenie = false;
                        pool_f[i].SetActive(true);
                        break;
                    }
                    if (name_f == "Piramida(Clone)")
                    {
                        pool_f[i].gameObject.transform.position = new Vector2(0.2f, 3.6f);
                        pool_f[i].gameObject.GetComponent<Piramida>().angle = 0;
                        pool_f[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        pool_f[i].gameObject.GetComponent<Piramida>().speed = 0.1f;
                        pool_f[i].gameObject.GetComponent<Piramida>().isStolknovenie = false;
                        pool_f[i].SetActive(true);
                        break;
                    }
                    if (name_f == "Square(Clone)")
                    {
                        pool_f[i].gameObject.transform.position = new Vector2(0.0f, 3.6f);
                        pool_f[i].gameObject.GetComponent<Square>().speed = 0.1f;
                        pool_f[i].gameObject.GetComponent<Square>().isStolknovenie = false;
                        pool_f[i].SetActive(true);
                        break;
                    }
                    if (name_f == "Stick(Clone)")
                    {
                        pool_f[i].gameObject.transform.position = new Vector2(0.0f, 3.4f);
                        pool_f[i].gameObject.GetComponent<Stick>().angle = 0;
                        pool_f[i].gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        pool_f[i].gameObject.GetComponent<Stick>().speed = 0.1f;
                        pool_f[i].gameObject.GetComponent<Stick>().isStolknovenie = false;
                        pool_f[i].SetActive(true);
                        break;
                    }
                }
            }
        }
    }

    void Controller_f()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            for (int i = 0; i < pool_f.Count; i++)
            {
                if (pool_f[i].gameObject.activeInHierarchy)
                {
                    if (pool_f[i].gameObject.name == "Angle_L(Clone)") { pool_f[i].gameObject.GetComponent<Angle_L>().Left(); }
                    if (pool_f[i].gameObject.name == "Angle_R(Clone)") { pool_f[i].gameObject.GetComponent<Angle_R>().Left(); }
                    if (pool_f[i].gameObject.name == "Piramida(Clone)") { pool_f[i].gameObject.GetComponent<Piramida>().Left(); }
                    if (pool_f[i].gameObject.name == "L(Clone)") { pool_f[i].gameObject.GetComponent<L>().Left(); }
                    if (pool_f[i].gameObject.name == "No_L(Clone)") { pool_f[i].gameObject.GetComponent<No_L>().Left(); }
                    if (pool_f[i].gameObject.name == "Square(Clone)") { pool_f[i].gameObject.GetComponent<Square>().Left(); }
                    if (pool_f[i].gameObject.name == "Stick(Clone)") { pool_f[i].gameObject.GetComponent<Stick>().Left(); }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            for (int i = 0; i < pool_f.Count; i++)
            {
                if (pool_f[i].gameObject.activeInHierarchy)
                {
                    if (pool_f[i].gameObject.name == "Angle_L(Clone)") { pool_f[i].gameObject.GetComponent<Angle_L>().Right(); }
                    if (pool_f[i].gameObject.name == "Angle_R(Clone)") { pool_f[i].gameObject.GetComponent<Angle_R>().Right(); }
                    if (pool_f[i].gameObject.name == "Piramida(Clone)") { pool_f[i].gameObject.GetComponent<Piramida>().Right(); }
                    if (pool_f[i].gameObject.name == "L(Clone)") { pool_f[i].gameObject.GetComponent<L>().Right(); }
                    if (pool_f[i].gameObject.name == "No_L(Clone)") { pool_f[i].gameObject.GetComponent<No_L>().Right(); }
                    if (pool_f[i].gameObject.name == "Square(Clone)") { pool_f[i].gameObject.GetComponent<Square>().Right(); }
                    if (pool_f[i].gameObject.name == "Stick(Clone)") { pool_f[i].gameObject.GetComponent<Stick>().Right(); }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            for (int i = 0; i < pool_f.Count; i++)
            {
                if (pool_f[i].gameObject.activeInHierarchy)
                {
                    if (pool_f[i].gameObject.name == "Angle_L(Clone)") { pool_f[i].gameObject.GetComponent<Angle_L>().Rotate(); }
                    if (pool_f[i].gameObject.name == "Angle_R(Clone)") { pool_f[i].gameObject.GetComponent<Angle_R>().Rotate(); }
                    if (pool_f[i].gameObject.name == "Piramida(Clone)") { pool_f[i].gameObject.GetComponent<Piramida>().Rotate(); }
                    if (pool_f[i].gameObject.name == "L(Clone)") { pool_f[i].gameObject.GetComponent<L>().Rotate(); }
                    if (pool_f[i].gameObject.name == "No_L(Clone)") { pool_f[i].gameObject.GetComponent<No_L>().Rotate(); }
                    if (pool_f[i].gameObject.name == "Stick(Clone)") { pool_f[i].gameObject.GetComponent<Stick>().Rotate(); }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            for (int i = 0; i < pool_f.Count; i++)
            {
                if (pool_f[i].gameObject.activeInHierarchy)
                {
                    if (pool_f[i].gameObject.name == "Angle_L(Clone)") { pool_f[i].gameObject.GetComponent<Angle_L>().Down(); }
                    if (pool_f[i].gameObject.name == "Angle_R(Clone)") { pool_f[i].gameObject.GetComponent<Angle_R>().Down(); }
                    if (pool_f[i].gameObject.name == "Piramida(Clone)") { pool_f[i].gameObject.GetComponent<Piramida>().Down(); }
                    if (pool_f[i].gameObject.name == "L(Clone)") { pool_f[i].gameObject.GetComponent<L>().Down(); }
                    if (pool_f[i].gameObject.name == "No_L(Clone)") { pool_f[i].gameObject.GetComponent<No_L>().Down(); }
                    if (pool_f[i].gameObject.name == "Square(Clone)") { pool_f[i].gameObject.GetComponent<Square>().Down(); }
                    if (pool_f[i].gameObject.name == "Stick(Clone)") { pool_f[i].gameObject.GetComponent<Stick>().Down(); }
                }
            }
        }
    }

    void Square_dno() 
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "Square(Clone)")
            {
                float x = pool_f[i].gameObject.transform.position.x;
                if (pool_f[i].gameObject.transform.position.y - 0.21f < -4.6)
                {
                    for (int t = 19 * 10; t < pool.Count; t++)
                    {
                        if (pool[t].gameObject.transform.position.x + 0.1f >= x + 0.21f && pool[t].gameObject.transform.position.x - 0.1f <= x + 0.21f)
                        {
                            map[19, t - (19 * 10) - 1] = 1;
                            map[19, t - (19 * 10)] = 1;
                            map[19 - 1, t - (19 * 10) - 1] = 1;
                            map[19 - 1, t - (19 * 10)] = 1;
                            Draw();
                            kol_square += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                    }
                }
            }
        }
    }

    void Square_control() 
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.name == "Square(Clone)" && pool_f[i].gameObject.activeInHierarchy)
            {
                int indexer_block = 0;
                float x = pool_f[i].gameObject.transform.position.x;
                float y = pool_f[i].gameObject.transform.position.y - 0.61f;
                for (int j = 0; j < pool.Count; j++)
                {
                    if (pool[j].gameObject.activeInHierarchy
                        && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.2f
                        && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.2f
                        && pool[j].gameObject.transform.position.y + 0.1f > y
                        && pool[j].gameObject.transform.position.y - 0.1f < y)
                    {
                        int s = indexer_block / 10;
                        int st = indexer_block - s * 10;
                        map[s - 1, st] = 1;
                        map[s - 1, st + 1] = 1;
                        map[s - 2, st] = 1;
                        map[s - 2, st + 1] = 1;
                        Draw();
                        kol_square += 1;
                        pool_f[i].gameObject.SetActive(false);
                        break;
                    }

                    if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                    {
                        int s = indexer_block / 10;
                        int st = indexer_block - s * 10;
                        map[s - 1, st - 1] = 1;
                        map[s - 1, st] = 1;
                        map[s - 2, st - 1] = 1;
                        map[s - 2, st] = 1;
                        Draw();
                        kol_square += 1;
                        pool_f[i].gameObject.SetActive(false);
                        break;
                    }
                    indexer_block += 1;
                }
            }
        }
    }

    void Stick_control() 
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "Stick(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<Stick>().angle == 0)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.41f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f > x - 0.6f
                            && pool[j].gameObject.transform.position.x - 0.1f < x - 0.6f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 1, st + 2] = 1;
                            map[s - 1, st + 3] = 1;
                            Draw();
                            kol_stick += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }

                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f > x - 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f < x - 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 1, st + 2] = 1;
                            Draw();
                            kol_stick += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }

                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f > x + 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f < x + 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st - 2] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            Draw();
                            kol_stick += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }

                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f > x + 0.6f
                            && pool[j].gameObject.transform.position.x - 0.1f < x + 0.6f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st - 3] = 1;
                            map[s - 1, st - 2] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st] = 1;
                            Draw();
                            kol_stick += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }

                        indexer_block += 1;
                    }
                }
                else
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 1.01f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy && pool[j].gameObject.transform.position.x + 0.1f > x && pool[j].gameObject.transform.position.x - 0.1f < x && pool[j].gameObject.transform.position.y + 0.1f > y && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            map[s - 3, st] = 1;
                            map[s - 4, st] = 1;
                            Draw();
                            kol_stick += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }

            }
        }
    }

    void Stick_dno() 
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "Stick(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<Stick>().angle == 0)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.21f;
                    if (y < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f > x - 0.6f
                            && pool[t].gameObject.transform.position.x - 0.1f < x - 0.6f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19, t - (19 * 10) + 1] = 1;
                                map[19, t - (19 * 10) + 2] = 1;
                                map[19, t - (19 * 10) + 3] = 1;
                                Draw();
                                kol_stick += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.61f;
                    if (y < -4.6)
                    {
                        Debug.Log("hi");
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x && pool[t].gameObject.transform.position.x - 0.1f <= x)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19 - 2, t - (19 * 10)] = 1;
                                map[19 - 3, t - (19 * 10)] = 1;
                                Draw();
                                kol_stick += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    void Angle_L_control() 
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "Angle_L(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<Angle_L>().angle == 0 || pool_f[i].gameObject.GetComponent<Angle_L>().angle == 180)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.61f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy && pool[j].gameObject.transform.position.x + 0.1f >= x
                            && pool[j].gameObject.transform.position.x - 0.1f <= x && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 2, st] = 1;
                            map[s - 2, st - 1] = 1;
                            Draw();
                            kol_angle_l += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.4f && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 2, st - 1] = 1;
                            map[s - 2, st - 2] = 1;
                            Draw();
                            kol_angle_l += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    y = pool_f[i].gameObject.transform.position.y - 0.21f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s, st + 1] = 1;
                            map[s, st + 2] = 1;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            Draw();
                            kol_angle_l += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }
                else
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.81f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.2f && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            map[s - 2, st + 1] = 1;
                            map[s - 3, st + 1] = 1;
                            Draw();
                            kol_angle_l += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y + 0.4f
                            && pool[j].gameObject.transform.position.y - 0.1f < y + 0.4f)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s, st - 1] = 1;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 2, st] = 1;
                            Draw();
                            kol_angle_l += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }
            }
        }
    }
    
    void Angle_L_dno()
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "Angle_L(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<Angle_L>().angle == 0 || pool_f[i].gameObject.GetComponent<Angle_L>().angle == 180) 
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.21f < -4.6) 
                    {
                        Debug.Log("ho");
                        for (int t = 19 * 10; t < pool.Count; t++) 
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x && pool[t].gameObject.transform.position.x - 0.1f <= x) 
                            {
                                map[19, t - (19 * 10) + 1] = 1;
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) - 1] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                Draw();
                                kol_angle_l += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                } 
                else 
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.41f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++) 
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x - 0.2f && pool[t].gameObject.transform.position.x - 0.1f <= x - 0.2f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) + 1] = 1;
                                map[19 - 2, t - (19 * 10) + 1] = 1;
                                Draw();
                                kol_angle_l += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    void Angle_R_dno()
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "Angle_R(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<Angle_R>().angle == 0 || pool_f[i].gameObject.GetComponent<Angle_R>().angle == 180)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.21f < -4.6)
                    {
                        Debug.Log("ho");
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x && pool[t].gameObject.transform.position.x - 0.1f <= x)
                            {
                                map[19, t - (19 * 10) - 1] = 1;
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) + 1] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                Draw();
                                kol_angle_r += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.41f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x + 0.2f && pool[t].gameObject.transform.position.x - 0.1f <= x + 0.2f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) - 1] = 1;
                                map[19 - 2, t - (19 * 10) - 1] = 1;
                                Draw();
                                kol_angle_r += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    void Angle_R_control()
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "Angle_R(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<Angle_R>().angle == 0 || pool_f[i].gameObject.GetComponent<Angle_R>().angle == 180)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.21f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s, st - 1] = 1;
                            map[s, st - 2] = 1;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            Draw();
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    y = pool_f[i].gameObject.transform.position.y - 0.61f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy && pool[j].gameObject.transform.position.x + 0.1f >= x
                            && pool[j].gameObject.transform.position.x - 0.1f <= x && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 2, st] = 1;
                            map[s - 2, st + 1] = 1;
                            Draw();
                            kol_angle_l += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.4f && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 2, st + 1] = 1;
                            map[s - 2, st + 2] = 1;
                            Draw();
                            kol_angle_l += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }
                else
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.81f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.21f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.21f
                            && pool[j].gameObject.transform.position.y + 0.1f > y + 0.4f
                            && pool[j].gameObject.transform.position.y - 0.1f < y + 0.4f)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s, st + 1] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            Draw();
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.21f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.21f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            map[s - 2, st - 1] = 1;
                            map[s - 3, st - 1] = 1;
                            Draw();
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                }
            }
        }
    }

    void L_dno() 
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "L(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<L>().angle == 0)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.21f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x + 0.4f && pool[t].gameObject.transform.position.x - 0.1f <= x + 0.4f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) - 1] = 1;
                                map[19 - 1, t - (19 * 10) - 2] = 1;
                                Draw();
                                kol_L += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }

                if (pool_f[i].gameObject.GetComponent<L>().angle == 90)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.41f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x - 0.2f && pool[t].gameObject.transform.position.x - 0.1f <= x - 0.2f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 2, t - (19 * 10) + 1] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19 - 2, t - (19 * 10)] = 1;
                                Draw();
                                kol_L += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }

                if (pool_f[i].gameObject.GetComponent<L>().angle == 180)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.21f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x - 0.4f && pool[t].gameObject.transform.position.x - 0.1f <= x - 0.4f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19, t - (19 * 10) + 1] = 1;
                                map[19, t - (19 * 10) + 2] = 1;
                                Draw();
                                kol_L += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }

                if (pool_f[i].gameObject.GetComponent<L>().angle == 270)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.41f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x - 0.2f && pool[t].gameObject.transform.position.x - 0.1f <= x - 0.2f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19, t - (19 * 10) + 1] = 1;
                                map[19 - 1, t - (19 * 10) + 1] = 1;
                                map[19 - 2, t - (19 * 10) + 1] = 1;
                                Draw();
                                kol_L += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    void L_control() 
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "L(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<L>().angle == 0)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.61f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            map[s - 2, st - 1] = 1;
                            map[s - 2, st - 2] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    y = pool_f[i].gameObject.transform.position.y - 0.21f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 1, st + 2] = 1;
                            map[s, st + 2] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x
                            && pool[j].gameObject.transform.position.x - 0.1f <= x
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s, st + 1] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                }

                if (pool_f[i].gameObject.GetComponent<L>().angle == 90)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.81f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            map[s - 3, st] = 1;
                            map[s - 3, st + 1] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    y = pool_f[i].gameObject.transform.position.y;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s, st] = 1;
                            map[s + 1, st] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }

                if (pool_f[i].gameObject.GetComponent<L>().angle == 180)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.61f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st - 2] = 1;
                            map[s - 2, st - 2] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 1, st + 2] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x
                            && pool[j].gameObject.transform.position.x - 0.1f <= x
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 2, st - 1] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }


                }

                if (pool_f[i].gameObject.GetComponent<L>().angle == 270)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.81f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 2, st] = 1;
                            map[s - 3, st] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 2, st + 1] = 1;
                            map[s - 3, st + 1] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }
            }
        }
    }

    void No_L_dno()
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "No_L(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<No_L>().angle == 0)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.21f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x - 0.4f && pool[t].gameObject.transform.position.x - 0.1f <= x - 0.4f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) + 1] = 1;
                                map[19 - 1, t - (19 * 10) + 2] = 1;
                                Draw();
                                kol_No_L += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }

                if (pool_f[i].gameObject.GetComponent<No_L>().angle == 90)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.41f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x - 0.2f && pool[t].gameObject.transform.position.x - 0.1f <= x - 0.2f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 2, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19, t - (19 * 10) + 1] = 1;
                                Draw();
                                kol_No_L += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }

                if (pool_f[i].gameObject.GetComponent<No_L>().angle == 180)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.21f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x - 0.4f && pool[t].gameObject.transform.position.x - 0.1f <= x - 0.4f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) + 2] = 1;
                                map[19, t - (19 * 10) + 1] = 1;
                                map[19, t - (19 * 10) + 2] = 1;
                                Draw();
                                kol_No_L += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }

                if (pool_f[i].gameObject.GetComponent<No_L>().angle == 270)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.41f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x - 0.2f && pool[t].gameObject.transform.position.x - 0.1f <= x + 0.2f)
                            {
                                map[19 - 2, t - (19 * 10)] = 1;
                                map[19, t - (19 * 10) + 1] = 1;
                                map[19 - 1, t - (19 * 10) + 1] = 1;
                                map[19 - 2, t - (19 * 10) + 1] = 1;
                                Draw();
                                kol_No_L += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    void No_L_control()
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "No_L(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<No_L>().angle == 0)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.61f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            map[s - 2, st + 1] = 1;
                            map[s - 2, st + 2] = 1;
                            Draw();
                            kol_No_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    y = pool_f[i].gameObject.transform.position.y - 0.21f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st - 2] = 1;
                            map[s, st - 2] = 1;
                            Draw();
                            kol_No_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x
                            && pool[j].gameObject.transform.position.x - 0.1f <= x
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s, st - 1] = 1;
                            Draw();
                            kol_No_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                }

                if (pool_f[i].gameObject.GetComponent<No_L>().angle == 90)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.81f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            map[s - 3, st] = 1;
                            map[s - 1, st + 1] = 1;
                            Draw();
                            kol_No_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.21f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.21f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 2, st - 1] = 1;
                            map[s - 3, st - 1] = 1;
                            Draw();
                            kol_No_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }

                if (pool_f[i].gameObject.GetComponent<No_L>().angle == 180)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.61f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st - 2] = 1;
                            map[s - 2, st] = 1;
                            Draw();
                            kol_No_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 1, st + 2] = 1;
                            map[s - 2, st + 2] = 1;
                            Draw();
                            kol_No_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x
                            && pool[j].gameObject.transform.position.x - 0.1f <= x
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 2, st + 1] = 1;
                            Draw();
                            kol_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }

                if (pool_f[i].gameObject.GetComponent<No_L>().angle == 270)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.81f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            map[s - 3, st] = 1;
                            map[s - 3, st - 1] = 1;
                            Draw();
                            kol_No_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                    indexer_block = 0;
                    y = pool_f[i].gameObject.transform.position.y;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s , st + 1] = 1;
                            map[s + 2, st + 1] = 1;
                            Draw();
                            kol_No_L += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }
            }
        }
    }

    void Piramida_dno()
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "Piramida(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<Piramida>().angle == 0)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.21f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x && pool[t].gameObject.transform.position.x - 0.1f <= x)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) + 1] = 1;
                                map[19 - 1, t - (19 * 10) - 1] = 1;
                                Draw();
                                kol_Piramida += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }

                if (pool_f[i].gameObject.GetComponent<Piramida>().angle == 90)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.61f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x - 0.2f && pool[t].gameObject.transform.position.x - 0.1f <= x - 0.2f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 2, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) + 1] = 1;
                                Draw();
                                kol_Piramida += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }

                if (pool_f[i].gameObject.GetComponent<Piramida>().angle == 180)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.21f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x - 0.4f && pool[t].gameObject.transform.position.x - 0.1f <= x - 0.4f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) + 1] = 1;
                                map[19, t - (19 * 10) + 1] = 1;
                                map[19, t - (19 * 10) + 2] = 1;
                                Draw();
                                kol_Piramida += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }

                if (pool_f[i].gameObject.GetComponent<Piramida>().angle == 270)
                {
                    float x = pool_f[i].gameObject.transform.position.x;
                    if (pool_f[i].gameObject.transform.position.y - 0.61f < -4.6)
                    {
                        for (int t = 19 * 10; t < pool.Count; t++)
                        {
                            if (pool[t].gameObject.transform.position.x + 0.1f >= x + 0.2f && pool[t].gameObject.transform.position.x - 0.1f <= x + 0.2f)
                            {
                                map[19, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10)] = 1;
                                map[19 - 2, t - (19 * 10)] = 1;
                                map[19 - 1, t - (19 * 10) -1] = 1;
                                Draw();
                                kol_Piramida += 1;
                                pool_f[i].gameObject.SetActive(false);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    void Piramida_control()
    {
        for (int i = 0; i < pool_f.Count; i++)
        {
            if (pool_f[i].gameObject.activeInHierarchy && pool_f[i].gameObject.name == "Piramida(Clone)")
            {
                if (pool_f[i].gameObject.GetComponent<Piramida>().angle == 0)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.21f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s, st + 1] = 1;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 1, st + 2] = 1;
                            Draw();
                            kol_Piramida += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st -2] = 1;
                            map[s, st - 1] = 1;
                            Draw();
                            kol_Piramida += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    y = pool_f[i].gameObject.transform.position.y - 0.61f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x
                            && pool[j].gameObject.transform.position.x - 0.1f <= x
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 2, st] = 1;
                            map[s - 2, st - 1] = 1;
                            map[s - 2, st + 1] = 1;
                            map[s - 1, st] = 1;
                            Draw();
                            kol_Piramida += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                }

                if (pool_f[i].gameObject.GetComponent<Piramida>().angle == 90)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.81f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st ] = 1;
                            map[s - 2, st] = 1;
                            map[s - 3, st] = 1;
                            map[s - 2, st + 1] = 1;
                            Draw();
                            kol_Piramida += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    y = pool_f[i].gameObject.transform.position.y - 0.41f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.21f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.21f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 2, st - 1] = 1;
                            map[s, st - 1] = 1;
                            Draw();
                            kol_Piramida += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }

                if (pool_f[i].gameObject.GetComponent<Piramida>().angle == 180)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.61f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st - 2] = 1;
                            map[s - 2, st - 1] = 1;
                            Draw();
                            kol_Piramida += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.4f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.4f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 1, st + 2] = 1;
                            map[s - 2, st + 1] = 1;
                            Draw();
                            kol_Piramida += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }

                    indexer_block = 0;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x
                            && pool[j].gameObject.transform.position.x - 0.1f <= x
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st - 1] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s - 2, st] = 1;
                            Draw();
                            kol_Piramida += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }

                if (pool_f[i].gameObject.GetComponent<Piramida>().angle == 270)
                {
                    int indexer_block = 0;
                    float x = pool_f[i].gameObject.transform.position.x;
                    float y = pool_f[i].gameObject.transform.position.y - 0.81f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x + 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x + 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 2, st] = 1;
                            map[s - 3, st] = 1;
                            map[s - 2, st - 1] = 1;
                            Draw();
                            kol_Piramida += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                    indexer_block = 0;
                    y = pool_f[i].gameObject.transform.position.y;
                    y = pool_f[i].gameObject.transform.position.y - 0.41f;
                    for (int j = 0; j < pool.Count; j++)
                    {
                        if (pool[j].gameObject.activeInHierarchy
                            && pool[j].gameObject.transform.position.x + 0.1f >= x - 0.2f
                            && pool[j].gameObject.transform.position.x - 0.1f <= x - 0.2f
                            && pool[j].gameObject.transform.position.y + 0.1f > y
                            && pool[j].gameObject.transform.position.y - 0.1f < y)
                        {
                            int s = indexer_block / 10;
                            int st = indexer_block - s * 10;
                            map[s - 1, st] = 1;
                            map[s - 1, st + 1] = 1;
                            map[s, st + 1] = 1;
                            map[s - 2, st + 1] = 1;
                            Draw();
                            kol_Piramida += 1;
                            pool_f[i].gameObject.SetActive(false);
                            break;
                        }
                        indexer_block += 1;
                    }
                }
            }
        }
    }



}