defmodule AdventOneTest do
  use ExUnit.Case
  doctest AdventOne

  test "Task one" do
    assert AdventOne.sum_list(["-2", "+5", "+2", "-3"]) == 2
    assert AdventOne.sum_list([]) == 0
  end

  test "Task two" do
    assert AdventOne.find_repeat(["+1","-1"]) == 0
    assert AdventOne.find_repeat(["+3","+3","+4","-2","-4"]) == 10
    assert AdventOne.find_repeat(["-6","+3","+8","+5","-6"]) == 5
    assert AdventOne.find_repeat(["+7","+7","-2","-7","-4"]) == 14
  end
end
