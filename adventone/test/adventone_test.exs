defmodule AdventOneTest do
  use ExUnit.Case
  doctest AdventOne

  test "the truth" do
    assert AdventOne.sum_list(["-2", "+5", "+2", "-3"]) == 2
    assert AdventOne.sum_list([]) == 0
  end
end
