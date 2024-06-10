using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [HideInInspector]
    public SkillChoiceController skillChoiceController;

    [HideInInspector]
    public int SkillNum;

    [HideInInspector]
    public  SkillInfo skill;

    protected SphereCollider coll;
    [SerializeField]
    protected MeshRenderer Icon_mesh;

    [SerializeField]
    protected GameObject Skill_obj;
   
   

    public virtual void Init()
    {
        coll = GetComponent<SphereCollider>();
        Icon_mesh = FindInChildren(this.transform, "Icon")?.GetComponent<MeshRenderer>();
        if (Icon_mesh == null) print("Icon이라는 오브젝트가 없습니다");
    }

    private void OnEnable()
    {
        Skill_obj.SetActive(true);
    }

    Transform FindInChildren(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child;

            Transform result = FindInChildren(child, name);
            if (result != null)
                return result;
        }
        return null;
    }

    public virtual void Setting(CharacterManager.ChoicedCharacter choicedCharacter, int skill_Id)
    {
        if((int)choicedCharacter == 0)
        {
            skill = SkillManager.instance.warriorSkills[skill_Id];
            Icon_mesh.material = skill.Material;
            
        }
        else
        {
            skill = SkillManager.instance.archerSkills[skill_Id];
            Icon_mesh.material =skill.Material;
        }
    }


    public virtual void GetSkill()
    {
        skillChoiceController.GetSkill(skill);
        Skill_obj.SetActive(false);

    }
}
