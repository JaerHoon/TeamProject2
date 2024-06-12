using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillChoiceController : MonoBehaviour
{
    public enum StageType { stage, Maerket }
    public StageType stageType;
    public enum SkillType { NormalATK, SkillATK, ItemRelic }
    public SkillType skillType;

    public Platform[] platforms = new Platform[3];

    Inventory inventory;
   

    private void Start()
    {
        inventory = GameObject.FindAnyObjectByType<Inventory>();
        platforms = GetComponentsInChildren<Platform>();
    }

    public void Setting()
    {
        if(platforms[0] == null)
        {
            platforms = GetComponentsInChildren<Platform>();
        }
        
        switch (skillType)
        {
            case SkillType.NormalATK: NormalATKSetting(); break;
            case SkillType.SkillATK: SkillATKSetting(); break;
            case SkillType.ItemRelic: ItemRelicSetting(); break;
        }
    }

    void NormalATKSetting()
    {
        if (CharacterManager.instance.choicedCharacter == CharacterManager.ChoicedCharacter.Warrior)
        {
            List<SkillInfo> skills = SkillManager.instance.warriorSkills.Where(n => n.skillType == SkillInfo.SkillType.NormalATK).ToList();

            for (int i = 0; i < skills.Count; i++)
            {
                if (skills[i].id == SkillManager.instance.gainedSkill_Warrior[0].id)
                {
                    skills.RemoveAt(i);
                }
            }

            int num = Random.Range(0, skills.Count);

            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].stageType = stageType;
                platforms[i].Setting(CharacterManager.ChoicedCharacter.Warrior, skills[i].id);
                platforms[i].skillChoiceController = this;
            }
        }
        else
        {

            List<SkillInfo> skills = SkillManager.instance.archerSkills.Where(n => n.skillType == SkillInfo.SkillType.NormalATK).ToList();

            for (int i = 0; i < skills.Count; i++)
            {
                if (skills[i].id == SkillManager.instance.gainedSkill_Archer[0].id)
                {
                    skills.RemoveAt(i);
                }
            }

           

            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].stageType = stageType;
                platforms[i].Setting(CharacterManager.ChoicedCharacter.Archer, skills[i].id);
                platforms[i].skillChoiceController = this;
            }

        }
    }

    void SkillATKSetting()
    {
        if (CharacterManager.instance.choicedCharacter == CharacterManager.ChoicedCharacter.Warrior)
        {
            List<SkillInfo> skills = SkillManager.instance.warriorSkills.Where(n => n.skillType == SkillInfo.SkillType.SkillATK).ToList();

            for (int i = 0; i < skills.Count; i++)
            {
                if (skills[i].id == SkillManager.instance.gainedSkill_Warrior[1].id)
                {
                    skills.RemoveAt(i);
                }
            }

          

            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].stageType = stageType;
                platforms[i].Setting(CharacterManager.ChoicedCharacter.Warrior, skills[i].id);
                platforms[i].skillChoiceController = this;
            }
        }
        else
        {
            List<SkillInfo> skills = SkillManager.instance.archerSkills.Where(n => n.skillType == SkillInfo.SkillType.SkillATK).ToList();

            for (int i = 0; i < skills.Count; i++)
            {
                if (skills[i].id == SkillManager.instance.gainedSkill_Archer[1].id)
                {
                    skills.RemoveAt(i);
                }
            }

            int num = Random.Range(0, skills.Count);

            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].stageType = stageType;
                platforms[i].Setting(CharacterManager.ChoicedCharacter.Archer, skills[i].id);
                platforms[i].skillChoiceController = this;
            }

        }
    }

    void ItemRelicSetting()
    {
        List<BaseItem> NoGaineditem = ItemManager.instance.items.Except(inventory.invenItems).ToList();

        int[] num = RandomNumber.RandomCreate(platforms.Length, 0, NoGaineditem.Count);

        for(int i=0; i < platforms.Length; i++)
        {
            platforms[i].stageType = stageType;
            platforms[i].Setting(NoGaineditem[i]);
            platforms[i].skillChoiceController = this;
        }
      
    }


    public void GetSkill(SkillInfo skill)
    {
        SkillManager.instance.GetSkill(CharacterManager.instance.choicedCharacter, skill);
       
    }

    public void GetItemRelic(BaseItem item)
    {
        inventory.AddItem(item);
        this.gameObject.SetActive(false);
    }

 }
