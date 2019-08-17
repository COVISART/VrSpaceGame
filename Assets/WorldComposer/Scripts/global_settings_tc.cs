using System;

#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;

[Serializable]
public class global_settings_tc : MonoBehaviour
{
    public int tc_script_id;
    public bool tc_installed;
    public Texture2D check_image;
    public string[] examples;
    public bool layer_count;
    public bool placed_count;
    public bool display_project;
    public bool tabs;
    public bool color_scheme;
    public color_settings_class color_layout;
    public bool color_layout_converted;
    public bool box_scheme;
    public bool display_color_curves;
    public bool display_mix_curves;
    public bool filter_select_text;
    public string install_path;
    public string install_path_full;
    public bool object_fast;
    public bool preview_texture;
    public int preview_texture_buffer;
    public bool preview_colors;
    public int preview_texture_resolution;
    public int preview_texture_resolution1;
    public int preview_quick_resolution_min;
    public float preview_splat_brightness;
    public bool preview_texture_dock;
    public int preview_target_frame;
    public List<Color> splat_colors;
    public int splat_custom_texture_resolution;
    public int splat_custom_texture_resolution1;
    public List<Color> tree_colors;
    public List<Color> grass_colors;
    public List<Color> object_colors;
    public bool toggle_text_no;
    public bool toggle_text_short;
    public bool toggle_text_long;
    public bool tooltip_text_no;
    public bool tooltip_text_short;
    public bool tooltip_text_long;
    public int tooltip_mode;
    public bool video_help;
    public bool run_in_background;
    public bool display_bar_auto_generate;
    public bool unload_textures;
    public bool clean_memory;
    public bool auto_speed;
    public int target_frame;
    public bool auto_save;
    public int auto_save_tc_instances;
    public int auto_save_scene_instances;
    public bool auto_save_tc;
    public List<string> auto_save_tc_list;
    public bool auto_save_scene;
    public List<string> auto_save_scene_list;
    public float auto_save_timer;
    public float auto_save_time_start;
    public bool auto_save_on_play;
    public string auto_save_path;
    public int terrain_tiles_max;
    public List<auto_search_class> auto_search_list;
    public map_class map;
    public Texture2D tex1;
    public Texture2D tex2;
    public Texture2D tex3;
    public Texture2D tex4;
    public select_window_class select_window;
    public List<int> preview_window;
    public float PI;
    public Texture2D map0;
    public Texture2D map1;
    public Texture2D map2;
    public Texture2D map3;
    public Texture2D map4;
    public bool map_combine;
    public bool map_load;
    public bool map_load2;
    public bool map_load3;
    public bool map_load4;
    public int map_zoom1;
    public int map_zoom2;
    public int map_zoom3;
    public int map_zoom4;

    public latlong_class map_latlong;
    public latlong_class map_latlong_center;
    public int map_zoom;
    public int map_zoom_old;
    public global_settings_class settings;
    public double minLatitude;
    public double maxLatitude;
    public double minLongitude;
    public double maxLongitude;

    public global_settings_tc()
    {
        this.examples = new string[]
        {
            "Procedural Mountains",
            "Procedural Canyons",
            "Procedural Plateaus",
            "Procedural Islands",
            "Island Example"
        };
        this.layer_count = true;
        this.placed_count = true;
        this.display_project = true;
        this.tabs = true;
        this.color_scheme = true;
        this.color_layout = new color_settings_class();
        this.display_mix_curves = true;
        this.filter_select_text = true;
        this.object_fast = true;
        this.preview_texture = true;
        this.preview_texture_buffer = 100;
        this.preview_colors = true;
        this.preview_texture_resolution = 128;
        this.preview_texture_resolution1 = 128;
        this.preview_quick_resolution_min = 16;
        this.preview_splat_brightness = (float)1;
        this.preview_texture_dock = true;
        this.preview_target_frame = 30;
        this.splat_colors = new List<Color>();
        this.splat_custom_texture_resolution = 128;
        this.splat_custom_texture_resolution1 = 128;
        this.tree_colors = new List<Color>();
        this.grass_colors = new List<Color>();
        this.object_colors = new List<Color>();
        this.toggle_text_short = true;
        this.tooltip_text_long = true;
        this.tooltip_mode = 2;
        this.video_help = true;
        this.run_in_background = true;
        this.display_bar_auto_generate = true;
        this.auto_speed = true;
        this.target_frame = 40;
        this.auto_save = true;
        this.auto_save_tc_instances = 2;
        this.auto_save_scene_instances = 2;
        this.auto_save_tc = true;
        this.auto_save_tc_list = new List<string>();
        this.auto_save_scene = true;
        this.auto_save_scene_list = new List<string>();
        this.auto_save_timer = (float)10;
        this.auto_save_on_play = true;
        this.terrain_tiles_max = 15;
        this.auto_search_list = new List<auto_search_class>();
        this.map = new map_class();
        this.select_window = new select_window_class();
        this.preview_window = new List<int>();
        this.PI = 3.14159274f;
        this.map_latlong = new latlong_class();
        this.map_latlong_center = new latlong_class();
        this.map_zoom = 17;
        this.settings = new global_settings_class();
        this.minLatitude = (double)-85.05113f;
        this.maxLatitude = (double)85.05113f;
        this.minLongitude = (double)-180;
        this.maxLongitude = (double)180;
    }

    public void drawGUIBox(Rect rect, string text, Color backgroundColor, Color highlightColor, Color textColor)
    {
        GUI.color = new Color(1, 1, 1, map.alpha);

        GUI.color = new Color(1, 1, 1, backgroundColor.a);
        EditorGUI.DrawPreviewTexture(new Rect(rect.x, rect.y + 19, rect.width, rect.height - 19), tex2);
        // GUI.color = highlightColor;
        GUI.color = new Color(1, 1, 1, highlightColor.a);
        EditorGUI.DrawPreviewTexture(new Rect(rect.x, rect.y, rect.width, 19), tex3);

        GUI.color = textColor;
        EditorGUI.LabelField(new Rect(rect.x, rect.y + 1, rect.width, 19), text, EditorStyles.boldLabel);
        GUI.color = Color.white;
    }
    
    public Vector2 drawText(string text, Vector2 pos, bool background, Color color, Color backgroundColor, float rotation, float fontSize, bool bold, int mode)
    {
        Matrix4x4 identity = Matrix4x4.identity;
        Matrix4x4 identity2 = Matrix4x4.identity;
        int fontSize2 = GUI.skin.label.fontSize;
        FontStyle fontStyle = GUI.skin.label.fontStyle;
        Color color2 = GUI.color;
        GUI.skin.label.fontSize = (int)fontSize;
        if (bold)
        {
            GUI.skin.label.fontStyle = FontStyle.Bold;
        }
        else
        {
            GUI.skin.label.fontStyle = FontStyle.Normal;
        }
        Vector2 result = GUI.skin.GetStyle("Label").CalcSize(new GUIContent(text));
        identity2.SetTRS(new Vector3(pos.x, pos.y, (float)0), Quaternion.Euler((float)0, (float)0, rotation), Vector3.one);
        if (mode == 1)
        {
            GUI.matrix = identity2;
        }
        else if (mode == 2)
        {
            identity.SetTRS(new Vector3(-result.x / (float)2, -result.y, (float)0), Quaternion.identity, Vector3.one);
            GUI.matrix = identity2 * identity;
        }
        else if (mode == 3)
        {
            identity.SetTRS(new Vector3((float)0, -result.y, (float)0), Quaternion.identity, Vector3.one);
            GUI.matrix = identity2 * identity;
        }
        else if (mode == 4)
        {
            identity.SetTRS(new Vector3(-result.x / (float)2, -result.y / (float)2, (float)0), Quaternion.identity, Vector3.one);
            GUI.matrix = identity2 * identity;
        }
        else if (mode == 5)
        {
            identity.SetTRS(new Vector3(-result.x, (float)0, (float)0), Quaternion.identity, Vector3.one);
            GUI.matrix = identity2 * identity;
        }
        else if (mode == 6)
        {
            identity.SetTRS(new Vector3(-result.x, -result.y, (float)0), Quaternion.identity, Vector3.one);
            GUI.matrix = identity2 * identity;
        }
        if (background)
        {
            GUI.color = backgroundColor;
            if (!this.tex4)
            {
                this.tex4 = new Texture2D(1, 1);
            }
            EditorGUI.DrawPreviewTexture(new Rect((float)0, (float)0, result.x, result.y), this.tex4);
        }
        GUI.color = color;
        GUI.Label(new Rect((float)0, (float)0, result.x, result.y), text);
        GUI.skin.label.fontSize = fontSize2;
        GUI.skin.label.fontStyle = fontStyle;
        GUI.color = color2;
        GUI.matrix = Matrix4x4.identity;
        return result;
    }

    public bool drawText(Rect rect, edit_class edit, bool background, Color color, Color backgroundColor, float fontSize, bool bold, int mode)
    {
        Vector2 vector = default(Vector2);
        int fontSize2 = default(int);
        FontStyle fontStyle = default(FontStyle);
        Color color2 = GUI.color;
        Vector2 size = default(Vector2);
        if (background)
        {
            GUI.color = backgroundColor;
            EditorGUI.DrawPreviewTexture(new Rect(vector.x, vector.y, size.x, size.y), this.tex2);
        }
        GUI.color = color;
        if (!edit.edit)
        {
            fontSize2 = GUI.skin.label.fontSize;
            fontStyle = GUI.skin.label.fontStyle;
            GUI.skin.label.fontSize = (int)fontSize;
            if (bold)
            {
                GUI.skin.label.fontStyle = FontStyle.Bold;
            }
            else
            {
                GUI.skin.label.fontStyle = FontStyle.Normal;
            }
            size = GUI.skin.GetStyle("Label").CalcSize(new GUIContent(edit.default_text));
            vector = this.calc_rect_allign(rect, size, mode);
            GUI.Label(new Rect(vector.x, vector.y, size.x, size.y), edit.default_text);
            GUI.skin.label.fontSize = fontSize2;
            GUI.skin.label.fontStyle = fontStyle;
        }
        else
        {
            fontSize2 = GUI.skin.textField.fontSize;
            fontStyle = GUI.skin.textField.fontStyle;
            GUI.skin.textField.fontSize = (int)fontSize;
            if (bold)
            {
                GUI.skin.textField.fontStyle = FontStyle.Bold;
            }
            else
            {
                GUI.skin.textField.fontStyle = FontStyle.Normal;
            }
            size = GUI.skin.GetStyle("TextField").CalcSize(new GUIContent(edit.text));
            if (size.x < rect.width)
            {
                size.x = rect.width;
            }
            size.x += (float)10;
            vector = this.calc_rect_allign(rect, size, mode);
            edit.text = GUI.TextField(new Rect(vector.x, vector.y, size.x, size.y), edit.text);
            GUI.skin.textField.fontSize = fontSize2;
            GUI.skin.textField.fontStyle = fontStyle;
        }
        if (Event.current.button == 0 && Event.current.clickCount == 2 && Event.current.type == 0 && new Rect(vector.x, vector.y, size.x, size.y).Contains(Event.current.mousePosition))
        {
            edit.edit = !edit.edit;
        }
        bool arg_330_0;
        if (Event.current.keyCode == KeyCode.Return || Event.current.keyCode == KeyCode.Escape)
        {
            edit.edit = false;
            GUI.color = color2;
            arg_330_0 = true;
        }
        else
        {
            GUI.color = color2;
            arg_330_0 = false;
        }
        return arg_330_0;
    }

    public void drawText(Rect rect, string text, bool background, Color color, Color backgroundColor, float fontSize, bool bold, int mode)
    {
        Vector2 vector = default(Vector2);
        int fontSize2 = GUI.skin.label.fontSize;
        FontStyle fontStyle = GUI.skin.label.fontStyle;
        Color color2 = GUI.color;
        Vector2 size = default(Vector2);
        if (background)
        {
            GUI.color = backgroundColor;
            EditorGUI.DrawPreviewTexture(new Rect(vector.x, vector.y, size.x, size.y), this.tex2);
        }
        GUI.color = color;
        GUI.skin.label.fontSize = (int)fontSize;
        if (bold)
        {
            GUI.skin.label.fontStyle = FontStyle.Bold;
        }
        else
        {
            GUI.skin.label.fontStyle = FontStyle.Normal;
        }
        size = GUI.skin.GetStyle("Label").CalcSize(new GUIContent(text));
        vector = this.calc_rect_allign(rect, size, mode);
        GUI.Label(new Rect(vector.x, vector.y, size.x, size.y), text);
        GUI.skin.label.fontSize = fontSize2;
        GUI.skin.label.fontStyle = fontStyle;
        GUI.color = color2;
    }
    
    public bool drawGUIBox(Rect rect, edit_class edit, float fontSize, bool label2, float labelHeight, Color backgroundColor, Color highlightColor, Color highlightColor2, Color textColor, bool border, int width, Rect screen, bool select, Color select_color, bool active)
    {
        if (!select)
        {
            highlightColor += new Color(-0.3f, -0.3f, -0.3f);
            highlightColor2 += new Color(-0.3f, -0.3f, -0.3f);
        }
        GUI.color = highlightColor;
        EditorGUI.DrawPreviewTexture(new Rect(rect.x, rect.y, rect.width, labelHeight), this.tex2);
        bool result = this.drawText(rect, edit, false, textColor, new Color(0.1f, 0.1f, 0.1f, (float)1), fontSize, true, 6);
        if (label2)
        {
            GUI.color = highlightColor2;
            EditorGUI.DrawPreviewTexture(new Rect(rect.x, rect.yMax - labelHeight, rect.width, labelHeight), this.tex2);
            GUI.color = Color.white;
            if (!active)
            {
                Drawing_tc1.DrawLine(new Vector2(rect.x + (float)1, rect.y + labelHeight + (float)1), new Vector2(rect.xMax - (float)1, rect.yMax - labelHeight - (float)1), new Color((float)1, (float)0, (float)0, 0.7f), (float)3, false, screen);
                Drawing_tc1.DrawLine(new Vector2(rect.x + (float)1, rect.yMax - labelHeight - (float)1), new Vector2(rect.xMax - (float)1, rect.y + labelHeight + (float)1), new Color((float)1, (float)0, (float)0, 0.7f), (float)3, false, screen);
            }
        }
        else if (!active)
        {
            Drawing_tc1.DrawLine(new Vector2(rect.x + (float)1, rect.y + labelHeight + (float)1), new Vector2(rect.xMax - (float)1, rect.yMax - (float)1), new Color((float)1, (float)0, (float)0, 0.7f), (float)3, false, screen);
            Drawing_tc1.DrawLine(new Vector2(rect.x + (float)1, rect.yMax - (float)1), new Vector2(rect.xMax - (float)1, rect.y + labelHeight + (float)1), new Color((float)1, (float)0, (float)0, 0.7f), (float)3, false, screen);
        }
        if (border)
        {
            this.DrawRect(rect, highlightColor, (float)width, screen);
            Drawing_tc1.DrawLine(new Vector2(rect.x, rect.y + labelHeight), new Vector2(rect.xMax, rect.y + labelHeight), highlightColor, (float)width, false, screen);
            if (label2)
            {
                Drawing_tc1.DrawLine(new Vector2(rect.x, rect.yMax - labelHeight), new Vector2(rect.xMax, rect.yMax - labelHeight), highlightColor, (float)width, false, screen);
            }
        }
        GUI.color = Color.white;
        return result;
    }

    public void drawJoinNode(Rect rect, int length, string text, float fontSize, bool label2, float labelHeight, Color backgroundColor, Color highlightColor, Color highlightColor2, Color textColor, bool border, int width, Rect screen, bool select, Color select_color, bool active)
    {
        if (!select)
        {
            highlightColor += new Color(-0.3f, -0.3f, -0.3f);
            highlightColor2 += new Color(-0.3f, -0.3f, -0.3f);
        }
        GUI.color = highlightColor;
        for (int i = 0; i < length; i++)
        {
            EditorGUI.DrawPreviewTexture(new Rect(rect.x, rect.y + (float)i * this.select_window.node_zoom, rect.width, labelHeight), this.tex2);
        }
        for (int i = 0; i < length; i++)
        {
            if (i < length - 1)
            {
                Drawing_tc1.DrawLine(new Vector2(rect.x, rect.y + (float)(i + 1) * this.select_window.node_zoom), new Vector2(rect.xMax, rect.y + (float)(i + 1) * this.select_window.node_zoom), highlightColor, (float)width, false, screen);
            }
        }
        this.drawText(rect, text, false, textColor, new Color(0.1f, 0.1f, 0.1f, (float)1), fontSize, true, 6);
        if (border)
        {
            this.DrawRect(new Rect(rect.x, rect.y, rect.width, (float)length * this.select_window.node_zoom), highlightColor, (float)width, screen);
        }
        GUI.color = Color.white;
    }
    
    public Vector2 calc_rect_allign(Rect rect, Vector2 size, int mode)
    {
        Vector2 result = default(Vector2);
        if (mode == 1)
        {
            result.x = rect.x;
            result.y = rect.y;
        }
        else if (mode == 2)
        {
            result.x = rect.x + rect.width / (float)2 - size.x / (float)2;
            result.y = rect.yMax;
        }
        else if (mode == 3)
        {
            result.x = rect.x;
            result.y = rect.yMax;
        }
        else if (mode == 4)
        {
            result.x = rect.x + rect.width / (float)2 - size.x / (float)2;
            result.y = rect.y + rect.height / (float)2 - size.y / (float)2;
        }
        else if (mode == 5)
        {
            result.x = rect.xMax - size.x;
            result.y = rect.y;
        }
        else if (mode == 6)
        {
            result.x = rect.x + rect.width / (float)2 - size.x / (float)2;
            result.y = rect.y - size.y;
        }
        return result;
    }

    public int label_width(string text, bool bold)
    {
        Vector2 vector = default(Vector2);
        if (bold)
        {
            FontStyle fontStyle = GUI.skin.label.fontStyle;
            GUI.skin.label.fontStyle = FontStyle.Bold;
            vector = GUI.skin.GetStyle("Label").CalcSize(new GUIContent(text));
            GUI.skin.label.fontStyle = fontStyle;
        }
        else
        {
            vector = GUI.skin.GetStyle("Label").CalcSize(new GUIContent(text));
        }
        return (int)vector.x;
    }

    public void DrawRect(Rect rect, Color color, float width, Rect screen)
    {
        Drawing_tc1.DrawLine(new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMax, rect.yMin), color, width, false, screen);
        Drawing_tc1.DrawLine(new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMin, rect.yMax), color, width, false, screen);
        Drawing_tc1.DrawLine(new Vector2(rect.xMin, rect.yMax), new Vector2(rect.xMax, rect.yMax), color, width, false, screen);
        Drawing_tc1.DrawLine(new Vector2(rect.xMax, rect.yMin), new Vector2(rect.xMax, rect.yMax), color, width, false, screen);
    }

    public void draw_arrow(Vector2 point1, int length, int length_arrow, float rotation, Color color, int width, Rect screen)
    {
        length_arrow = (int)(Mathf.Sqrt(2f) * (float)length_arrow);
        Vector2 vector = this.calc_rotation_pixel(point1.x, point1.y - (float)length, point1.x, point1.y, rotation);
        Vector2 pointB = this.calc_rotation_pixel(vector.x - (float)length_arrow, vector.y - (float)length_arrow, vector.x, vector.y, (float)-180 + rotation);
        Vector2 pointB2 = this.calc_rotation_pixel(vector.x + (float)length_arrow, vector.y - (float)length_arrow, vector.x, vector.y, (float)180 + rotation);
        Drawing_tc1.DrawLine(point1, vector, color, (float)width, false, screen);
        Drawing_tc1.DrawLine(vector, pointB, color, (float)width, false, screen);
        Drawing_tc1.DrawLine(vector, pointB2, color, (float)width, false, screen);
    }

    public bool draw_latlong_raster(latlong_class latlong1, latlong_class latlong2, Vector2 offset, double zoom, double current_zoom, int resolution, Rect screen, Color color, int width)
    {
        bool result = true;
        Vector2 vector = this.latlong_to_pixel(latlong1, this.map_latlong_center, current_zoom, new Vector2(screen.width, screen.height));
        Vector2 vector2 = this.latlong_to_pixel(latlong2, this.map_latlong_center, current_zoom, new Vector2(screen.width, screen.height));
        Vector2 vector3 = vector2 - vector;
        vector += new Vector2(-offset.x, offset.y);
        vector2 += new Vector2(-offset.x, offset.y);
        double num = (double)Mathf.Pow((float)2, (float)(zoom - current_zoom));
        float num2 = (float)((double)resolution / num);
        if (Mathf.Abs(Mathf.Round(vector3.x / num2) - vector3.x / num2) > 0.01f || Mathf.Abs(Mathf.Round(vector3.y / num2) - vector3.y / num2) > 0.01f)
        {
            result = false;
            color = Color.red;
        }
        for (float num3 = vector.x; num3 < vector.x + vector3.x; num3 += num2)
        {
            Drawing_tc1.DrawLine(new Vector2(num3, vector.y), new Vector2(num3, vector2.y), color, (float)width, false, screen);
        }
        for (float num4 = vector.y; num4 < vector.y + vector3.y; num4 += num2)
        {
            Drawing_tc1.DrawLine(new Vector2(vector.x, num4), new Vector2(vector2.x, num4), color, (float)width, false, screen);
        }
        return result;
    }

    public void draw_grid(Rect rect, int tile_x, int tile_y, Color color, int width, Rect screen)
    {
        Vector2 vector = default(Vector2);
        vector.x = rect.width / (float)tile_x;
        vector.y = rect.height / (float)tile_y;
        for (float num = rect.x; num <= rect.xMax + vector.x / (float)2; num += vector.x)
        {
            Drawing_tc1.DrawLine(new Vector2(num, rect.y), new Vector2(num, rect.yMax), color, (float)width, false, screen);
        }
        for (float num2 = rect.y; num2 <= rect.yMax + vector.y / (float)2; num2 += vector.y)
        {
            Drawing_tc1.DrawLine(new Vector2(rect.x, num2), new Vector2(rect.xMax, num2), color, (float)width, false, screen);
        }
    }

    public void draw_scale_grid(Rect rect, Vector2 offset, float zoom, float scale, Color color, int width, bool draw_center, Rect screen)
    {
        Vector2 vector = new Vector2(screen.width, screen.height) / (float)2 + offset;
        float num2 = vector.x - rect.x;
        float num3 = vector.y - rect.y;
        int num4 = (int)(num2 / zoom);
        num4 = (int)(num2 - (float)num4 * zoom);
        num4 = (int)((float)num4 + rect.x);
        int num5 = this.calc_rest_value((vector.x - (float)num4) / zoom, (float)10);
        if (num5 < 0)
        {
            num5 = -9 - num5;
        }
        else
        {
            num5 = 9 - num5;
        }
        int num7 = (int)(num3 / zoom);
        num7 = (int)(num3 - (float)num7 * zoom);
        num7 = (int)((float)num7 + rect.y);
        for (float num8 = (float)num4; num8 <= rect.xMax; num8 += zoom)
        {
            Drawing_tc1.DrawLine(new Vector2(num8, rect.y), new Vector2(num8, rect.yMax), color, (float)width, false, screen);
            if (num5 > 9)
            {
                num5 = 0;
            }
            num5++;
        }
        for (float num9 = (float)num7; num9 <= rect.yMax; num9 += zoom)
        {
            Drawing_tc1.DrawLine(new Vector2(rect.x, num9), new Vector2(rect.xMax, num9), color, (float)width, false, screen);
        }
        if (draw_center)
        {
            Drawing_tc1.DrawLine(new Vector2(vector.x, rect.y), new Vector2(vector.x, rect.yMax), color, (float)(width + 2), false, screen);
            Drawing_tc1.DrawLine(new Vector2(rect.x, vector.y), new Vector2(rect.xMax, vector.y), color, (float)(width + 2), false, screen);
        }
    }

    public Vector2 calc_rotation_pixel(float x, float y, float xx, float yy, float rotation)
    {
        Vector2 result = new Vector2(x - xx, y - yy);
        float magnitude = result.magnitude;
        if (magnitude != (float)0)
        {
            result.x /= magnitude;
            result.y /= magnitude;
        }
        float num = Mathf.Acos(result.x);
        if (result.y < (float)0)
        {
            num = this.PI * (float)2 - num;
        }
        num -= rotation * 0.0174532924f;
        result.x = Mathf.Cos(num) * magnitude + xx;
        result.y = Mathf.Sin(num) * magnitude + yy;
        return result;
    }

    public double clip(double n, double minValue, double maxValue)
    {
        return this.calcMin(this.calcMax(n, minValue), maxValue);
    }

    public latlong_class clip_latlong(latlong_class latlong)
    {
        if (latlong.latitude > this.maxLatitude)
        {
            latlong.latitude -= this.maxLatitude * (double)2;
        }
        else if (latlong.latitude < this.minLatitude)
        {
            latlong.latitude += this.maxLatitude * (double)2;
        }
        if (latlong.longitude > (double)180)
        {
            latlong.longitude -= (double)360;
        }
        else if (latlong.longitude < (double)-180)
        {
            latlong.longitude += (double)360;
        }
        return latlong;
    }

    public map_pixel_class clip_pixel(map_pixel_class map_pixel, double zoom)
    {
        double num = (double)((float)256 * Mathf.Pow((float)2, (float)zoom));
        if (map_pixel.x > num - (double)1)
        {
            map_pixel.x -= num - (double)1;
        }
        else if (map_pixel.x < (double)0)
        {
            map_pixel.x = num - (double)1 - map_pixel.x;
        }
        if (map_pixel.y > num - (double)1)
        {
            map_pixel.y -= num - (double)1;
        }
        else if (map_pixel.y < (double)0)
        {
            map_pixel.y = num - (double)1 - map_pixel.y;
        }
        return map_pixel;
    }

    public double calcMin(double a, double b)
    {
        return (a >= b) ? b : a;
    }

    public double calcMax(double a, double b)
    {
        return (a <= b) ? b : a;
    }

    public int mapSize(int zoom)
    {
        return (int)(Mathf.Pow((float)2, (float)zoom) * (float)256);
    }

    public Vector2 latlong_to_pixel(latlong_class latlong, latlong_class latlong_center, double zoom, Vector2 screen_resolution)
    {
        latlong = this.clip_latlong(latlong);
        latlong_center = this.clip_latlong(latlong_center);
        double num = (double)3.14159274f;
        double num2 = (latlong.longitude + (double)180) / (double)360;
        double num3 = (double)Mathf.Sin((float)(latlong.latitude * num / (double)180));
        double num4 = (double)0.5f - (double)Mathf.Log((float)(((double)1 + num3) / ((double)1 - num3))) / ((double)4 * num);
        Vector2 vector = new Vector2((float)num2, (float)num4);
        num2 = (latlong_center.longitude + (double)180) / (double)360;
        num3 = (double)Mathf.Sin((float)(latlong_center.latitude * num / (double)180));
        num4 = (double)0.5f - (double)Mathf.Log((float)(((double)1 + num3) / ((double)1 - num3))) / ((double)4 * num);
        Vector2 vector2 = new Vector2((float)num2, (float)num4);
        Vector2 vector3 = vector - vector2;
        vector3 *= (float)256 * Mathf.Pow((float)2, (float)zoom);
        return vector3 + screen_resolution / (float)2;
    }

    public map_pixel_class latlong_to_pixel2(latlong_class latlong, double zoom)
    {
        latlong = this.clip_latlong(latlong);
        double num = (double)3.14159274f;
        double num2 = (latlong.longitude + (double)180f) / (double)360f;
        double num3 = (double)Mathf.Sin((float)(latlong.latitude * num / (double)180f));
        double num4 = (double)0.5f - (double)Mathf.Log((float)(((double)1f + num3) / ((double)1f - num3))) / ((double)4f * num);
        num2 *= (double)(256f * Mathf.Pow(2f, (float)zoom));
        num4 *= (double)(256f * Mathf.Pow(2f, (float)zoom));
        return new map_pixel_class
        {
            x = num2,
            y = num4
        };
    }

    public latlong_class pixel_to_latlong2(map_pixel_class map_pixel, double zoom)
    {
        map_pixel = this.clip_pixel(map_pixel, zoom);
        double num = (double)3.14159274f;
        double num2 = (double)(256f * Mathf.Pow(2f, (float)zoom));
        double num3 = map_pixel.x / num2 - (double)0.5f;
        double num4 = (double)0.5f - map_pixel.y / num2;
        return new latlong_class
        {
            latitude = (double)90f - (double)(360f * Mathf.Atan(Mathf.Exp((float)(-(float)num4 * (double)2f * num)))) / num,
            longitude = (double)360f * num3
        };
    }

    public latlong_class pixel_to_latlong(Vector2 offset, latlong_class latlong_center, double zoom)
    {
        double num = (double)3.14159274f;
        double num2 = (double)((float)256 * Mathf.Pow((float)2, (float)zoom));
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(latlong_center, zoom);
        map_pixel_class map_pixel_class2 = new map_pixel_class();
        map_pixel_class2.x = map_pixel_class.x + (double)offset.x;
        map_pixel_class2.y = map_pixel_class.y + (double)offset.y;
        double num3 = map_pixel_class2.x / num2 - (double)0.5f;
        double num4 = (double)0.5f - map_pixel_class2.y / num2;
        return this.clip_latlong(new latlong_class
        {
            latitude = (double)90 - (double)((float)360 * Mathf.Atan(Mathf.Exp((float)(-(float)num4 * (double)2 * num)))) / num,
            longitude = (double)360 * num3
        });
    }

    public map_pixel_class calc_latlong_area_size(latlong_class latlong1, latlong_class latlong2, latlong_class latlong_center)
    {
        double num = (double)3.14159274f;
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(latlong1, (double)19);
        map_pixel_class map_pixel_class2 = this.latlong_to_pixel2(latlong2, (double)19);
        double num2 = (double)(156543.047f * Mathf.Cos((float)(latlong_center.latitude * (num / (double)180))) / Mathf.Pow((float)2, (float)19));
        return new map_pixel_class
        {
            x = (map_pixel_class2.x - map_pixel_class.x) * num2,
            y = (map_pixel_class2.y - map_pixel_class.y) * num2
        };
    }

    public double calc_latlong_area_resolution(latlong_class latlong, double zoom)
    {
        double num = (double)3.14159274f;
        return (double)(156543.047f * Mathf.Cos((float)(latlong.latitude * (num / (double)180))) / Mathf.Pow((float)2, (float)zoom));
    }

    public latlong_area_class calc_latlong_area_rounded(latlong_class latlong1, latlong_class latlong2, double zoom, int resolution, bool square, int mode)
    {
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(latlong1, zoom);
        map_pixel_class map_pixel_class2 = this.latlong_to_pixel2(latlong2, zoom);
        map_pixel_class map_pixel_class3 = new map_pixel_class();
        map_pixel_class3.x = (double)(Mathf.Round((float)((map_pixel_class2.x - map_pixel_class.x) / (double)resolution)) * (float)resolution);
        if (square)
        {
            map_pixel_class3.y = map_pixel_class3.x;
        }
        else
        {
            map_pixel_class3.y = (double)(Mathf.Round((float)((map_pixel_class2.y - map_pixel_class.y) / (double)resolution)) * (float)resolution);
        }
        if (mode == 1)
        {
            if (map_pixel_class.x > map_pixel_class2.x - (double)resolution)
            {
                map_pixel_class.x = map_pixel_class2.x - (double)resolution;
            }
            else
            {
                map_pixel_class.x = map_pixel_class2.x - map_pixel_class3.x;
            }
        }
        else if (mode == 2)
        {
            if (map_pixel_class2.x < map_pixel_class.x + (double)resolution)
            {
                map_pixel_class2.x = map_pixel_class.x + (double)resolution;
            }
            else
            {
                map_pixel_class2.x = map_pixel_class.x + map_pixel_class3.x;
            }
        }
        else if (mode == 3)
        {
            if (map_pixel_class.y > map_pixel_class2.y - (double)resolution)
            {
                map_pixel_class.y = map_pixel_class2.y - (double)resolution;
            }
            else
            {
                map_pixel_class.y = map_pixel_class2.y - map_pixel_class3.y;
            }
        }
        else if (mode == 4)
        {
            if (map_pixel_class2.y < map_pixel_class.y + (double)resolution)
            {
                map_pixel_class2.y = map_pixel_class.y + (double)resolution;
            }
            else
            {
                map_pixel_class2.y = map_pixel_class.y + map_pixel_class3.y;
            }
        }
        else if (mode == 5)
        {
            if (map_pixel_class.x > map_pixel_class2.x - (double)resolution)
            {
                map_pixel_class.x = map_pixel_class2.x - (double)resolution;
            }
            else
            {
                map_pixel_class.x = map_pixel_class2.x - map_pixel_class3.x;
            }
            if (map_pixel_class.y > map_pixel_class2.y - (double)resolution)
            {
                map_pixel_class.y = map_pixel_class2.y - (double)resolution;
            }
            else
            {
                map_pixel_class.y = map_pixel_class2.y - map_pixel_class3.y;
            }
        }
        else if (mode == 6)
        {
            if (map_pixel_class2.x < map_pixel_class.x + (double)resolution)
            {
                map_pixel_class2.x = map_pixel_class.x + (double)resolution;
            }
            else
            {
                map_pixel_class2.x = map_pixel_class.x + map_pixel_class3.x;
            }
            if (map_pixel_class.y > map_pixel_class2.y - (double)resolution)
            {
                map_pixel_class.y = map_pixel_class2.y - (double)resolution;
            }
            else
            {
                map_pixel_class.y = map_pixel_class2.y - map_pixel_class3.y;
            }
        }
        else if (mode == 7)
        {
            if (map_pixel_class.x > map_pixel_class2.x - (double)resolution)
            {
                map_pixel_class.x = map_pixel_class2.x - (double)resolution;
            }
            else
            {
                map_pixel_class.x = map_pixel_class2.x - map_pixel_class3.x;
            }
            if (map_pixel_class2.y < map_pixel_class.y + (double)resolution)
            {
                map_pixel_class2.y = map_pixel_class.y + (double)resolution;
            }
            else
            {
                map_pixel_class2.y = map_pixel_class.y + map_pixel_class3.y;
            }
        }
        else if (mode == 8)
        {
            if (map_pixel_class2.x - (double)resolution < map_pixel_class.x)
            {
                map_pixel_class2.x = map_pixel_class.x + (double)resolution;
            }
            else
            {
                map_pixel_class2.x = map_pixel_class.x + map_pixel_class3.x;
            }
            if (map_pixel_class2.y - (double)resolution < map_pixel_class.y)
            {
                map_pixel_class2.y = map_pixel_class.y + (double)resolution;
            }
            else
            {
                map_pixel_class2.y = map_pixel_class.y + map_pixel_class3.y;
            }
        }
        return new latlong_area_class
        {
            latlong1 = this.pixel_to_latlong2(map_pixel_class, zoom),
            latlong2 = this.pixel_to_latlong2(map_pixel_class2, zoom)
        };
    }

    public tile_class calc_latlong_area_tiles(latlong_class latlong1, latlong_class latlong2, double zoom, int resolution)
    {
        tile_class tile_class = new tile_class();
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(latlong1, zoom);
        map_pixel_class map_pixel_class2 = this.latlong_to_pixel2(latlong2, zoom);
        tile_class.x = (int)Mathf.Round((float)((map_pixel_class2.x - map_pixel_class.x) / (double)resolution));
        tile_class.y = (int)Mathf.Round((float)((map_pixel_class2.y - map_pixel_class.y) / (double)resolution));
        return tile_class;
    }

    public latlong_class calc_latlong_center(latlong_class latlong1, latlong_class latlong2, double zoom, Vector2 screen_resolution)
    {
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(latlong1, zoom);
        map_pixel_class map_pixel_class2 = this.latlong_to_pixel2(latlong2, zoom);
        return this.pixel_to_latlong2(new map_pixel_class
        {
            x = (map_pixel_class.x + map_pixel_class2.x) / (double)2,
            y = (map_pixel_class.y + map_pixel_class2.y) / (double)2
        }, zoom);
    }

    public void calc_latlong_area_from_center(map_area_class area, latlong_class center, double zoom, Vector2 resolution)
    {
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(area.center, zoom);
        map_pixel_class map_pixel_class2 = this.latlong_to_pixel2(center, zoom);
        map_pixel_class map_pixel_class3 = this.latlong_to_pixel2(area.upper_left, zoom);
        map_pixel_class map_pixel_class4 = this.latlong_to_pixel2(area.lower_right, zoom);
        map_pixel_class map_pixel_class5 = new map_pixel_class();
        map_pixel_class5.x = map_pixel_class2.x - map_pixel_class.x;
        map_pixel_class5.y = map_pixel_class2.y - map_pixel_class.y;
        map_pixel_class3.x += map_pixel_class5.x;
        map_pixel_class3.y += map_pixel_class5.y;
        map_pixel_class4.x = map_pixel_class3.x + (double)resolution.x;
        map_pixel_class4.y = map_pixel_class3.y + (double)resolution.y;
        area.upper_left = this.pixel_to_latlong2(map_pixel_class3, zoom);
        area.lower_right = this.pixel_to_latlong2(map_pixel_class4, zoom);
        area.center = center;
    }

    public void calc_latlong1_area_from_center(map_area_class area, latlong_class center, double zoom)
    {
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(area.upper_left, zoom);
        map_pixel_class map_pixel_class2 = this.latlong_to_pixel2(center, zoom);
        map_pixel_class map_pixel_class3 = this.latlong_to_pixel2(area.center, zoom);
        map_pixel_class map_pixel_class4 = this.latlong_to_pixel2(area.lower_right, zoom);
        map_pixel_class map_pixel_class5 = new map_pixel_class();
        map_pixel_class5.x = map_pixel_class2.x - map_pixel_class.x;
        map_pixel_class5.y = map_pixel_class2.y - map_pixel_class.y;
        map_pixel_class3.x += map_pixel_class5.x;
        map_pixel_class3.y += map_pixel_class5.y;
        map_pixel_class4.x += map_pixel_class5.x;
        map_pixel_class4.y += map_pixel_class5.y;
        area.upper_left = center;
        area.center = this.pixel_to_latlong2(map_pixel_class3, zoom);
        area.lower_right = this.pixel_to_latlong2(map_pixel_class4, zoom);
    }

    public void calc_latlong2_area_from_center(map_area_class area, latlong_class center, double zoom)
    {
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(area.lower_right, zoom);
        map_pixel_class map_pixel_class2 = this.latlong_to_pixel2(center, zoom);
        map_pixel_class map_pixel_class3 = this.latlong_to_pixel2(area.center, zoom);
        map_pixel_class map_pixel_class4 = this.latlong_to_pixel2(area.upper_left, zoom);
        map_pixel_class map_pixel_class5 = new map_pixel_class();
        map_pixel_class5.x = map_pixel_class2.x - map_pixel_class.x;
        map_pixel_class5.y = map_pixel_class2.y - map_pixel_class.y;
        map_pixel_class3.x += map_pixel_class5.x;
        map_pixel_class3.y += map_pixel_class5.y;
        map_pixel_class4.x += map_pixel_class5.x;
        map_pixel_class4.y += map_pixel_class5.y;
        area.lower_right = center;
        area.center = this.pixel_to_latlong2(map_pixel_class3, zoom);
        area.upper_left = this.pixel_to_latlong2(map_pixel_class4, zoom);
    }

    public Vector2 calc_pixel_zoom(Vector2 pixel, double zoom, double current_zoom, Vector2 screen_resolution)
    {
        double num = (double)Mathf.Pow((float)2, (float)(zoom - current_zoom));
        Vector2 vector = pixel - screen_resolution;
        vector *= (float)num;
        return vector + screen_resolution;
    }

    public latlong_area_class calc_latlong_area_by_tile(latlong_class latlong, tile_class tile, double zoom, int resolution, Vector2 bresolution, Vector2 offset)
    {
        float num = Mathf.Pow((float)2, (float)((double)19 - zoom));
        zoom = (double)19;
        resolution = (int)((float)resolution * num);
        bresolution *= num;
        latlong_area_class latlong_area_class = new latlong_area_class();
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(latlong, zoom);
        Vector2 vector = new Vector2((float)0, (float)0);
        map_pixel_class.x += (double)((float)(tile.x * resolution) + offset.x);
        map_pixel_class.y += (double)((float)(tile.y * resolution) + offset.y);
        if (tile.x > 0)
        {
            map_pixel_class.x += (double)num;
            vector.x = num;
        }
        if (tile.y > 0)
        {
            map_pixel_class.y += (double)num;
            vector.y = num;
        }
        latlong_class latlong_class = this.pixel_to_latlong2(map_pixel_class, zoom);
        latlong_area_class.latlong1 = latlong_class;
        map_pixel_class.x += (double)(bresolution.x - vector.x);
        map_pixel_class.y += (double)(bresolution.y - vector.y);
        latlong_class = this.pixel_to_latlong2(map_pixel_class, zoom);
        latlong_area_class.latlong2 = latlong_class;
        return latlong_area_class;
    }

    public latlong_area_class calc_latlong_area_by_tile2(latlong_class latlong, tile_class tile, double zoom, int resolution, Vector2 bresolution)
    {
        latlong_area_class latlong_area_class = new latlong_area_class();
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(latlong, zoom);
        map_pixel_class.x += (double)(tile.x * resolution);
        map_pixel_class.y += (double)(tile.y * resolution);
        latlong_class latlong_class = this.pixel_to_latlong2(map_pixel_class, zoom);
        latlong_area_class.latlong1 = latlong_class;
        map_pixel_class.x += (double)bresolution.x;
        map_pixel_class.y += (double)bresolution.y;
        latlong_class = this.pixel_to_latlong2(map_pixel_class, zoom);
        latlong_area_class.latlong2 = latlong_class;
        return latlong_area_class;
    }

    public latlong_class calc_latlong_center_by_tile(latlong_class latlong, tile_class tile, tile_class subtile, tile_class subtiles, double zoom, int resolution, Vector2 offset)
    {
        float num = Mathf.Pow((float)2, (float)((double)19 - zoom));
        zoom = (double)19;
        resolution = (int)((float)resolution * num);
        map_pixel_class map_pixel_class = this.latlong_to_pixel2(latlong, zoom);
        map_pixel_class.x += (double)(tile.x * subtiles.x * resolution + subtile.x * resolution);
        map_pixel_class.y += (double)(tile.y * subtiles.y * resolution + subtile.y * resolution);
        map_pixel_class.x += (double)((float)(resolution / 2) + offset.x);
        map_pixel_class.y += (double)((float)(resolution / 2) + offset.y);
        return this.pixel_to_latlong2(map_pixel_class, zoom);
    }

    public int calc_rest_value(float value1, float divide)
    {
        int num = (int)(value1 / divide);
        return (int)(value1 - (float)num * divide);
    }

    public map_pixel_class calc_latlong_to_mercator(latlong_class latlong)
    {
        map_pixel_class map_pixel_class = new map_pixel_class();
        map_pixel_class.x = latlong.latitude * (double)20037508f / (double)180;
        map_pixel_class.y = (double)(Mathf.Log(Mathf.Tan((float)(((double)90 + latlong.longitude) * (double)3.14159274f / (double)360))) / 0.0174532924f);
        map_pixel_class.y = map_pixel_class.y * (double)20037508f / (double)180;
        return map_pixel_class;
    }

    public latlong_class calc_mercator_to_latlong(map_pixel_class pixel)
    {
        latlong_class latlong_class = new latlong_class();
        latlong_class.longitude = pixel.x / (double)20037508f * (double)180;
        latlong_class.latitude = pixel.y / (double)20037508f * (double)180;
        latlong_class.latitude = (double)(57.2957764f * ((float)2 * Mathf.Atan(Mathf.Exp((float)(latlong_class.latitude * (double)3.14159274f / (double)180))) - 1.57079637f));
        return latlong_class;
    }

    public bool rect_contains(Rect rect1, Rect rect2)
    {
        return rect1.Contains(new Vector2(rect2.x, rect2.y)) || rect1.Contains(new Vector2(rect2.x, rect2.yMax)) || rect1.Contains(new Vector2(rect2.xMax, rect2.y)) || rect1.Contains(new Vector2(rect2.xMax, rect2.yMax));
    }

    public tile_class calc_terrain_tile(int terrain_index, tile_class tiles)
    {
        tile_class tile_class = new tile_class();
        tile_class.y = terrain_index / tiles.x;
        tile_class.x = terrain_index - tile_class.y * tiles.x;
        return tile_class;
    }

    public void set_image_import_settings(string path, bool read, TextureImporterFormat format, TextureWrapMode wrapmode, int maxsize, bool mipmapEnabled, FilterMode filterMode, int anisoLevel, int mode)
    {
        if (path.Length != 0)
        {
            path = path.Replace(Application.dataPath, "Assets");
            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            bool flag = false;
            if (textureImporter)
            {
                if ((mode & 1) != 0 && textureImporter.isReadable != read)
                {
                    textureImporter.isReadable = read;
                    flag = true;
                }
                #if UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4
                if ((mode & 2) != 0 && textureImporter.textureFormat != format)
                {
                    textureImporter.textureFormat = format;
                    flag = true;
                }
                #endif
                if ((mode & 4) != 0 && textureImporter.wrapMode != wrapmode)
                {
                    textureImporter.wrapMode = wrapmode;
                    flag = true; 
                }
                if ((mode & 8) != 0 && textureImporter.maxTextureSize != maxsize)
                {
                    textureImporter.maxTextureSize = maxsize;
                    flag = true;
                }
                if ((mode & 16) != 0 && textureImporter.mipmapEnabled != mipmapEnabled)
                {
                    textureImporter.mipmapEnabled = mipmapEnabled;
                    flag = true;
                }
                if ((mode & 32) != 0 && textureImporter.filterMode != filterMode)
                {
                    textureImporter.filterMode = filterMode;
                    flag = true;
                }
                if ((mode & 64) != 0 && textureImporter.anisoLevel != anisoLevel)
                {
                    textureImporter.anisoLevel = anisoLevel;
                    flag = true;
                }
                if (flag)
                {
                    AssetDatabase.ImportAsset(path);
                }
            }
            else
            {
                Debug.Log("Texture Importer can't find " + path);
            }
        }
    }
}

[Serializable]
public class gui_class
{
    public List<float> column;

    public float y;

    public float x;

    public gui_class(int columns)
    {
        this.column = new List<float>();
        for (int i = 0; i < columns; i++)
        {
            this.column.Add((float)0);
        }
    }

    public Rect getRect(int column_index, float width, float y1, bool add_width, bool add_height)
    {
        float num = this.x;
        float num2 = this.y;
        if (add_width)
        {
            this.x += width;
        }
        if (add_height)
        {
            this.y += y1;
        }
        return new Rect(this.column[column_index] + num, num2, width, y1);
    }

    public Rect getRect(int column_index, float x1, float width, float y1, bool add_width, bool add_height)
    {
        float num = this.x;
        float num2 = this.y;
        if (add_width)
        {
            this.x += width + x1;
        }
        if (add_height)
        {
            this.y += y1;
        }
        return new Rect(this.column[column_index] + num + x1, num2, width, y1);
    }
}

[Serializable]
public class image_edit_class
{
    public Color color1_start;

    public Color color1_end;

    public AnimationCurve curve1;

    public Color color2_start;

    public Color color2_end;

    public AnimationCurve curve2;

    public float strength;

    public image_output_enum output;

    public bool active;

    public bool solid_color;

    public float radius;

    public int repeat;

    public image_edit_class()
    {
        this.color1_start = new Color((float)0, (float)0, (float)0, (float)1);
        this.color1_end = new Color(0.3f, 0.3f, 0.3f, (float)1);
        this.curve1 = AnimationCurve.Linear((float)0, (float)0, (float)1, (float)1);
        this.color2_start = new Color((float)1, (float)1, (float)1, (float)1);
        this.color2_end = new Color((float)1, (float)1, (float)1, (float)1);
        this.curve2 = AnimationCurve.Linear((float)0, (float)0, (float)1, (float)1);
        this.strength = (float)1;
        this.active = true;
        this.radius = (float)300;
        this.repeat = 4;
    }
}

[Serializable]
public enum image_output_enum
{
    add,
    subtract,
    change,
    multiply,
    divide,
    difference,
    average,
    max,
    min,
    content
}

[Serializable]
public class JPGEncoder_class
{
    private int[] ZigZag;

    private int[] YTable;

    private int[] UVTable;

    private float[] fdtbl_Y;

    private float[] fdtbl_UV;

    private BitString[] YDC_HT;

    private BitString[] UVDC_HT;

    private BitString[] YAC_HT;

    private BitString[] UVAC_HT;

    private int[] std_dc_luminance_nrcodes;

    private int[] std_dc_luminance_values;

    private int[] std_ac_luminance_nrcodes;

    private int[] std_ac_luminance_values;

    private int[] std_dc_chrominance_nrcodes;

    private int[] std_dc_chrominance_values;

    private int[] std_ac_chrominance_nrcodes;

    private int[] std_ac_chrominance_values;

    private BitString[] bitcode;

    private int[] category;

    private int bytenew;

    private int bytepos;

    private ByteArray byteout;

    private int[] DU;

    private float[] YDU;

    private float[] UDU;

    private float[] VDU;

    public bool isDone;

    private BitmapData image;

    private int sf;

    public JPGEncoder_class(Texture2D texture, float quality)
    {
        this.ZigZag = new int[]
        {
            0,
            1,
            5,
            6,
            14,
            15,
            27,
            28,
            2,
            4,
            7,
            13,
            16,
            26,
            29,
            42,
            3,
            8,
            12,
            17,
            25,
            30,
            41,
            43,
            9,
            11,
            18,
            24,
            31,
            40,
            44,
            53,
            10,
            19,
            23,
            32,
            39,
            45,
            52,
            54,
            20,
            22,
            33,
            38,
            46,
            51,
            55,
            60,
            21,
            34,
            37,
            47,
            50,
            56,
            59,
            61,
            35,
            36,
            48,
            49,
            57,
            58,
            62,
            63
        };
        this.YTable = new int[64];
        this.UVTable = new int[64];
        this.fdtbl_Y = new float[64];
        this.fdtbl_UV = new float[64];
        this.std_dc_luminance_nrcodes = new int[]
        {
            0,
            0,
            1,
            5,
            1,
            1,
            1,
            1,
            1,
            1,
            0,
            0,
            0,
            0,
            0,
            0,
            0
        };
        this.std_dc_luminance_values = new int[]
        {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11
        };
        this.std_ac_luminance_nrcodes = new int[]
        {
            0,
            0,
            2,
            1,
            3,
            3,
            2,
            4,
            3,
            5,
            5,
            4,
            4,
            0,
            0,
            1,
            125
        };
        this.std_ac_luminance_values = new int[]
        {
            1,
            2,
            3,
            0,
            4,
            17,
            5,
            18,
            33,
            49,
            65,
            6,
            19,
            81,
            97,
            7,
            34,
            113,
            20,
            50,
            129,
            145,
            161,
            8,
            35,
            66,
            177,
            193,
            21,
            82,
            209,
            240,
            36,
            51,
            98,
            114,
            130,
            9,
            10,
            22,
            23,
            24,
            25,
            26,
            37,
            38,
            39,
            40,
            41,
            42,
            52,
            53,
            54,
            55,
            56,
            57,
            58,
            67,
            68,
            69,
            70,
            71,
            72,
            73,
            74,
            83,
            84,
            85,
            86,
            87,
            88,
            89,
            90,
            99,
            100,
            101,
            102,
            103,
            104,
            105,
            106,
            115,
            116,
            117,
            118,
            119,
            120,
            121,
            122,
            131,
            132,
            133,
            134,
            135,
            136,
            137,
            138,
            146,
            147,
            148,
            149,
            150,
            151,
            152,
            153,
            154,
            162,
            163,
            164,
            165,
            166,
            167,
            168,
            169,
            170,
            178,
            179,
            180,
            181,
            182,
            183,
            184,
            185,
            186,
            194,
            195,
            196,
            197,
            198,
            199,
            200,
            201,
            202,
            210,
            211,
            212,
            213,
            214,
            215,
            216,
            217,
            218,
            225,
            226,
            227,
            228,
            229,
            230,
            231,
            232,
            233,
            234,
            241,
            242,
            243,
            244,
            245,
            246,
            247,
            248,
            249,
            250
        };
        this.std_dc_chrominance_nrcodes = new int[]
        {
            0,
            0,
            3,
            1,
            1,
            1,
            1,
            1,
            1,
            1,
            1,
            1,
            0,
            0,
            0,
            0,
            0
        };
        this.std_dc_chrominance_values = new int[]
        {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11
        };
        this.std_ac_chrominance_nrcodes = new int[]
        {
            0,
            0,
            2,
            1,
            2,
            4,
            4,
            3,
            4,
            7,
            5,
            4,
            4,
            0,
            1,
            2,
            119
        };
        this.std_ac_chrominance_values = new int[]
        {
            0,
            1,
            2,
            3,
            17,
            4,
            5,
            33,
            49,
            6,
            18,
            65,
            81,
            7,
            97,
            113,
            19,
            34,
            50,
            129,
            8,
            20,
            66,
            145,
            161,
            177,
            193,
            9,
            35,
            51,
            82,
            240,
            21,
            98,
            114,
            209,
            10,
            22,
            36,
            52,
            225,
            37,
            241,
            23,
            24,
            25,
            26,
            38,
            39,
            40,
            41,
            42,
            53,
            54,
            55,
            56,
            57,
            58,
            67,
            68,
            69,
            70,
            71,
            72,
            73,
            74,
            83,
            84,
            85,
            86,
            87,
            88,
            89,
            90,
            99,
            100,
            101,
            102,
            103,
            104,
            105,
            106,
            115,
            116,
            117,
            118,
            119,
            120,
            121,
            122,
            130,
            131,
            132,
            133,
            134,
            135,
            136,
            137,
            138,
            146,
            147,
            148,
            149,
            150,
            151,
            152,
            153,
            154,
            162,
            163,
            164,
            165,
            166,
            167,
            168,
            169,
            170,
            178,
            179,
            180,
            181,
            182,
            183,
            184,
            185,
            186,
            194,
            195,
            196,
            197,
            198,
            199,
            200,
            201,
            202,
            210,
            211,
            212,
            213,
            214,
            215,
            216,
            217,
            218,
            226,
            227,
            228,
            229,
            230,
            231,
            232,
            233,
            234,
            242,
            243,
            244,
            245,
            246,
            247,
            248,
            249,
            250
        };
        this.bitcode = new BitString[65535];
        this.category = new int[65535];
        this.bytepos = 7;
        this.byteout = new ByteArray();
        this.DU = new int[64];
        this.YDU = new float[64];
        this.UDU = new float[64];
        this.VDU = new float[64];
        this.image = new BitmapData(texture);
        if (quality <= (float)0)
        {
            quality = (float)1;
        }
        if (quality > (float)100)
        {
            quality = (float)100;
        }
        if (quality < (float)50)
        {
            this.sf = (int)((float)5000 / quality);
        }
        else
        {
            this.sf = (int)((float)200 - quality * (float)2);
        }
        Thread thread = new Thread(new ThreadStart(this.doEncoding));
        thread.Start();
    }

    private void initQuantTables(int sf)
    {
        int i = default(int);
        float num = default(float);
        int[] array = new int[]
        {
            16,
            11,
            10,
            16,
            24,
            40,
            51,
            61,
            12,
            12,
            14,
            19,
            26,
            58,
            60,
            55,
            14,
            13,
            16,
            24,
            40,
            57,
            69,
            56,
            14,
            17,
            22,
            29,
            51,
            87,
            80,
            62,
            18,
            22,
            37,
            56,
            68,
            109,
            103,
            77,
            24,
            35,
            55,
            64,
            81,
            104,
            113,
            92,
            49,
            64,
            78,
            87,
            103,
            121,
            120,
            101,
            72,
            92,
            95,
            98,
            112,
            100,
            103,
            99
        };
        for (i = 0; i < 64; i++)
        {
            num = Mathf.Floor((float)((array[i] * sf + 50) / 100));
            if (num < (float)1)
            {
                num = (float)1;
            }
            else if (num > (float)255)
            {
                num = (float)255;
            }
            this.YTable[this.ZigZag[i]] = (int)num;
        }
        int[] array2 = new int[]
        {
            17,
            18,
            24,
            47,
            99,
            99,
            99,
            99,
            18,
            21,
            26,
            66,
            99,
            99,
            99,
            99,
            24,
            26,
            56,
            99,
            99,
            99,
            99,
            99,
            47,
            66,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99,
            99
        };
        for (i = 0; i < 64; i++)
        {
            num = Mathf.Floor((float)((array2[i] * sf + 50) / 100));
            if (num < (float)1)
            {
                num = (float)1;
            }
            else if (num > (float)255)
            {
                num = (float)255;
            }
            this.UVTable[this.ZigZag[i]] = (int)num;
        }
        float[] array3 = new float[]
        {
            1f,
            1.3870399f,
            1.306563f,
            1.17587554f,
            1f,
            0.785694957f,
            0.5411961f,
            0.27589938f
        };
        i = 0;
        for (int j = 0; j < 8; j++)
        {
            for (int k = 0; k < 8; k++)
            {
                this.fdtbl_Y[i] = 1f / ((float)this.YTable[this.ZigZag[i]] * array3[j] * array3[k] * 8f);
                this.fdtbl_UV[i] = 1f / ((float)this.UVTable[this.ZigZag[i]] * array3[j] * array3[k] * 8f);
                i++;
            }
        }
    }

    private BitString[] computeHuffmanTbl(int[] nrcodes, int[] std_table)
    {
        int num = 0;
        int num2 = 0;
        BitString[] array = new BitString[256];
        for (int i = 1; i <= 16; i++)
        {
            for (int j = 1; j <= nrcodes[i]; j++)
            {
                array[std_table[num2]] = new BitString();
                array[std_table[num2]].val = num;
                array[std_table[num2]].len = i;
                num2++;
                num++;
            }
            num *= 2;
        }
        return array;
    }

    private void initHuffmanTbl()
    {
        this.YDC_HT = this.computeHuffmanTbl(this.std_dc_luminance_nrcodes, this.std_dc_luminance_values);
        this.UVDC_HT = this.computeHuffmanTbl(this.std_dc_chrominance_nrcodes, this.std_dc_chrominance_values);
        this.YAC_HT = this.computeHuffmanTbl(this.std_ac_luminance_nrcodes, this.std_ac_luminance_values);
        this.UVAC_HT = this.computeHuffmanTbl(this.std_ac_chrominance_nrcodes, this.std_ac_chrominance_values);
    }

    private void initCategoryfloat()
    {
        int num = 1;
        int num2 = 2;
        int i = default(int);
        for (int j = 1; j <= 15; j++)
        {
            for (i = num; i < num2; i++)
            {
                this.category[32767 + i] = j;
                BitString bitString = new BitString();
                bitString.len = j;
                bitString.val = i;
                this.bitcode[32767 + i] = bitString;
            }
            for (i = -(num2 - 1); i <= -num; i++)
            {
                this.category[32767 + i] = j;
                BitString bitString = new BitString();
                bitString.len = j;
                bitString.val = num2 - 1 + i;
                this.bitcode[32767 + i] = bitString;
            }
            num <<= 1;
            num2 <<= 1;
        }
    }

    public byte[] GetBytes()
    {
        byte[] arg_28_0;
        if (!this.isDone)
        {
            Debug.LogError("JPEGEncoder not complete, cannot get bytes!");
            arg_28_0 = null;
        }
        else
        {
            arg_28_0 = this.byteout.GetAllBytes();
        }
        return arg_28_0;
    }

    private void writeBits(BitString bs)
    {
        int val = bs.val;
        int i = bs.len - 1;
        while (i >= 0)
        {
            if ((int)((long)val & Convert.ToUInt32(1 << i)) != 0)
            {
                this.bytenew = (int)(bytenew | (int)Convert.ToUInt32(1 << bytepos));
            }
            i--;
            this.bytepos--;
            if (this.bytepos < 0)
            {
                if (this.bytenew == 255)
                {
                    this.writeByte(255);
                    this.writeByte(0);
                }
                else
                {
                    this.writeByte((byte)this.bytenew);
                }
                this.bytepos = 7;
                this.bytenew = 0;
            }
        }
    }

    private void writeByte(byte value)
    {
        this.byteout.writeByte(value);
    }

    private void writeWord(int value)
    {
        this.writeByte((byte)(value >> 8 & 255));
        this.writeByte((byte)(value & 255));
    }

    private float[] fDCTQuant(float[] data, float[] fdtbl)
    {
        float num = default(float);
        float num2 = default(float);
        float num3 = default(float);
        float num4 = default(float);
        float num5 = default(float);
        float num6 = default(float);
        float num7 = default(float);
        float num8 = default(float);
        float num9 = default(float);
        float num10 = default(float);
        float num11 = default(float);
        float num12 = default(float);
        float num13 = default(float);
        float num14 = default(float);
        float num15 = default(float);
        float num16 = default(float);
        float num17 = default(float);
        float num18 = default(float);
        float num19 = default(float);
        int i = default(int);
        int num20 = 0;
        for (i = 0; i < 8; i++)
        {
            num = data[num20 + 0] + data[num20 + 7];
            num8 = data[num20 + 0] - data[num20 + 7];
            num2 = data[num20 + 1] + data[num20 + 6];
            num7 = data[num20 + 1] - data[num20 + 6];
            num3 = data[num20 + 2] + data[num20 + 5];
            num6 = data[num20 + 2] - data[num20 + 5];
            num4 = data[num20 + 3] + data[num20 + 4];
            num5 = data[num20 + 3] - data[num20 + 4];
            num9 = num + num4;
            num12 = num - num4;
            num10 = num2 + num3;
            num11 = num2 - num3;
            data[num20 + 0] = num9 + num10;
            data[num20 + 4] = num9 - num10;
            num13 = (num11 + num12) * 0.707106769f;
            data[num20 + 2] = num12 + num13;
            data[num20 + 6] = num12 - num13;
            num9 = num5 + num6;
            num10 = num6 + num7;
            num11 = num7 + num8;
            num17 = (num9 - num11) * 0.382683426f;
            num14 = 0.5411961f * num9 + num17;
            num16 = 1.306563f * num11 + num17;
            num15 = num10 * 0.707106769f;
            num18 = num8 + num15;
            num19 = num8 - num15;
            data[num20 + 5] = num19 + num14;
            data[num20 + 3] = num19 - num14;
            data[num20 + 1] = num18 + num16;
            data[num20 + 7] = num18 - num16;
            num20 += 8;
        }
        num20 = 0;
        for (i = 0; i < 8; i++)
        {
            num = data[num20 + 0] + data[num20 + 56];
            num8 = data[num20 + 0] - data[num20 + 56];
            num2 = data[num20 + 8] + data[num20 + 48];
            num7 = data[num20 + 8] - data[num20 + 48];
            num3 = data[num20 + 16] + data[num20 + 40];
            num6 = data[num20 + 16] - data[num20 + 40];
            num4 = data[num20 + 24] + data[num20 + 32];
            num5 = data[num20 + 24] - data[num20 + 32];
            num9 = num + num4;
            num12 = num - num4;
            num10 = num2 + num3;
            num11 = num2 - num3;
            data[num20 + 0] = num9 + num10;
            data[num20 + 32] = num9 - num10;
            num13 = (num11 + num12) * 0.707106769f;
            data[num20 + 16] = num12 + num13;
            data[num20 + 48] = num12 - num13;
            num9 = num5 + num6;
            num10 = num6 + num7;
            num11 = num7 + num8;
            num17 = (num9 - num11) * 0.382683426f;
            num14 = 0.5411961f * num9 + num17;
            num16 = 1.306563f * num11 + num17;
            num15 = num10 * 0.707106769f;
            num18 = num8 + num15;
            num19 = num8 - num15;
            data[num20 + 40] = num19 + num14;
            data[num20 + 24] = num19 - num14;
            data[num20 + 8] = num18 + num16;
            data[num20 + 56] = num18 - num16;
            num20++;
        }
        for (i = 0; i < 64; i++)
        {
            data[i] = Mathf.Round(data[i] * fdtbl[i]);
        }
        return data;
    }

    private void writeAPP0()
    {
        this.writeWord(65504);
        this.writeWord(16);
        this.writeByte(74);
        this.writeByte(70);
        this.writeByte(73);
        this.writeByte(70);
        this.writeByte(0);
        this.writeByte(1);
        this.writeByte(1);
        this.writeByte(0);
        this.writeWord(1);
        this.writeWord(1);
        this.writeByte(0);
        this.writeByte(0);
    }

    private void writeSOF0(int width, int height)
    {
        this.writeWord(65472);
        this.writeWord(17);
        this.writeByte(8);
        this.writeWord(height);
        this.writeWord(width);
        this.writeByte(3);
        this.writeByte(1);
        this.writeByte(17);
        this.writeByte(0);
        this.writeByte(2);
        this.writeByte(17);
        this.writeByte(1);
        this.writeByte(3);
        this.writeByte(17);
        this.writeByte(1);
    }

    private void writeDQT()
    {
        this.writeWord(65499);
        this.writeWord(132);
        this.writeByte(0);
        int i = default(int);
        for (i = 0; i < 64; i++)
        {
            this.writeByte((byte)this.YTable[i]);
        }
        this.writeByte(1);
        for (i = 0; i < 64; i++)
        {
            this.writeByte((byte)this.UVTable[i]);
        }
    }

    private void writeDHT()
    {
        this.writeWord(65476);
        this.writeWord(418);
        int i = default(int);
        this.writeByte(0);
        for (i = 0; i < 16; i++)
        {
            this.writeByte((byte)this.std_dc_luminance_nrcodes[i + 1]);
        }
        for (i = 0; i <= 11; i++)
        {
            this.writeByte((byte)this.std_dc_luminance_values[i]);
        }
        this.writeByte(16);
        for (i = 0; i < 16; i++)
        {
            this.writeByte((byte)this.std_ac_luminance_nrcodes[i + 1]);
        }
        for (i = 0; i <= 161; i++)
        {
            this.writeByte((byte)this.std_ac_luminance_values[i]);
        }
        this.writeByte(1);
        for (i = 0; i < 16; i++)
        {
            this.writeByte((byte)this.std_dc_chrominance_nrcodes[i + 1]);
        }
        for (i = 0; i <= 11; i++)
        {
            this.writeByte((byte)this.std_dc_chrominance_values[i]);
        }
        this.writeByte(17);
        for (i = 0; i < 16; i++)
        {
            this.writeByte((byte)this.std_ac_chrominance_nrcodes[i + 1]);
        }
        for (i = 0; i <= 161; i++)
        {
            this.writeByte((byte)this.std_ac_chrominance_values[i]);
        }
    }

    private void writeSOS()
    {
        this.writeWord(65498);
        this.writeWord(12);
        this.writeByte(3);
        this.writeByte(1);
        this.writeByte(0);
        this.writeByte(2);
        this.writeByte(17);
        this.writeByte(3);
        this.writeByte(17);
        this.writeByte(0);
        this.writeByte(63);
        this.writeByte(0);
    }

    private float processDU(float[] CDU, float[] fdtbl, float DC, BitString[] HTDC, BitString[] HTAC)
    {
        BitString bs = HTAC[0];
        BitString bs2 = HTAC[240];
        int i = default(int);
        float[] array = this.fDCTQuant(CDU, fdtbl);
        for (i = 0; i < 64; i++)
        {
            this.DU[this.ZigZag[i]] = (int)array[i];
        }
        int num = (int)((float)this.DU[0] - DC);
        DC = (float)this.DU[0];
        if (num == 0)
        {
            this.writeBits(HTDC[0]);
        }
        else
        {
            this.writeBits(HTDC[this.category[32767 + num]]);
            this.writeBits(this.bitcode[32767 + num]);
        }
        int num2 = 63;
        while (num2 > 0 && this.DU[num2] == 0)
        {
            num2--;
        }
        float arg_1A8_0;
        if (num2 == 0)
        {
            this.writeBits(bs);
            arg_1A8_0 = DC;
        }
        else
        {
            for (i = 1; i <= num2; i++)
            {
                int num3 = i;
                while (this.DU[i] == 0 && i <= num2)
                {
                    i++;
                }
                int num4 = i - num3;
                if (num4 >= 16)
                {
                    for (int j = 1; j <= num4 / 16; j++)
                    {
                        this.writeBits(bs2);
                    }
                    num4 &= 15;
                }
                this.writeBits(HTAC[num4 * 16 + this.category[32767 + this.DU[i]]]);
                this.writeBits(this.bitcode[32767 + this.DU[i]]);
            }
            if (num2 != 63)
            {
                this.writeBits(bs);
            }
            arg_1A8_0 = DC;
        }
        return arg_1A8_0;
    }

    private void RGB2YUV(BitmapData img, int xpos, int ypos)
    {
        int num = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Color pixelColor = img.getPixelColor(xpos + j, img.height - (ypos + i));
                float num2 = pixelColor.r * (float)255;
                float num3 = pixelColor.g * (float)255;
                float num4 = pixelColor.b * (float)255;
                this.YDU[num] = 0.299f * num2 + 0.587f * num3 + 0.114f * num4 - (float)128;
                this.UDU[num] = -0.16874f * num2 + -0.33126f * num3 + 0.5f * num4;
                this.VDU[num] = 0.5f * num2 + -0.41869f * num3 + -0.08131f * num4;
                num++;
            }
        }
    }

    private void doEncoding()
    {
        this.isDone = false;
        Thread.Sleep(5);
        this.initHuffmanTbl();
        this.initCategoryfloat();
        this.initQuantTables(this.sf);
        this.encode();
        this.isDone = true;
        this.image = null;
        Thread.CurrentThread.Abort();
    }

    private void encode()
    {
        this.byteout = new ByteArray();
        this.bytenew = 0;
        this.bytepos = 7;
        this.writeWord(65496);
        this.writeAPP0();
        this.writeDQT();
        this.writeSOF0(this.image.width, this.image.height);
        this.writeDHT();
        this.writeSOS();
        float dC = (float)0;
        float dC2 = (float)0;
        float dC3 = (float)0;
        this.bytenew = 0;
        this.bytepos = 7;
        for (int i = 0; i < this.image.height; i += 8)
        {
            for (int j = 0; j < this.image.width; j += 8)
            {
                this.RGB2YUV(this.image, j, i);
                dC = this.processDU(this.YDU, this.fdtbl_Y, dC, this.YDC_HT, this.YAC_HT);
                dC2 = this.processDU(this.UDU, this.fdtbl_UV, dC2, this.UVDC_HT, this.UVAC_HT);
                dC3 = this.processDU(this.VDU, this.fdtbl_UV, dC3, this.UVDC_HT, this.UVAC_HT);
                Thread.Sleep(0);
            }
        }
        if (this.bytepos >= 0)
        {
            this.writeBits(new BitString
            {
                len = this.bytepos + 1,
                val = (1 << this.bytepos + 1) - 1
            });
        }
        this.writeWord(65497);
        this.isDone = true;
    }
}

[Serializable]
public class latlong_area_class
{
    public latlong_class latlong1;

    public latlong_class latlong2;

    public latlong_area_class()
    {
        this.latlong1 = new latlong_class();
        this.latlong2 = new latlong_class();
    }
}

#endif

    [Serializable]
public class latlong_class
{
    public double latitude;

    public double longitude;

    public latlong_class()
    {
    }

    public latlong_class(double latitude1, double longitude1)
    {
        this.latitude = latitude1;
        this.longitude = longitude1;
    }

    public void reset()
    {
        this.latitude = (double)0;
        this.longitude = (double)0;
    }
}
